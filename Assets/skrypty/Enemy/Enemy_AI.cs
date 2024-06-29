using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    [SerializeField] Transform player;
    [SerializeField] LayerMask coToGround, ktoToPlayer;

    Vector3 walkPoint;
    bool walkPointSet;

    [SerializeField] float walkPointRange;

    [SerializeField] float timeBetweenAttacks;
    bool alreadyAttacked;

    [SerializeField] float sightRange, attackRange;
    bool playerInSightRange, playerInAttackRange;

    [SerializeField] Enemyshoot shoot;
    [SerializeField] Enemymelee melee;

    [SerializeField] GameObject gun;
    [SerializeField] GameObject noz;

    [SerializeField] double hp = 100;

    [SerializeField] GameObject hpPrefab, manaPrefab;

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, ktoToPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, ktoToPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrol();
        if (playerInSightRange && !playerInAttackRange) Chase();
        if (playerInSightRange && playerInAttackRange) Attack();
    }

    void Patrol()
    {
        agent.isStopped = false;
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 dystans = transform.position - walkPoint;

        if (dystans.magnitude < 1f)
            walkPointSet = false;
    }

    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, coToGround))
            walkPointSet = true;
    }

    void Chase()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
    }

    void Attack()
    {
        if (!alreadyAttacked)
        {
            if (gun != null)
            {
                shoot.Shoot();
                agent.SetDestination(transform.position);
                agent.isStopped = true;

                transform.LookAt(player);
            }
            else if (noz != null)
            {
                transform.LookAt(player);
                melee.Knife();
            }

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(double damage)
    {
        hp -= damage;
        Debug.Log("Enemy HP: " + hp);

        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Logika œmierci przeciwnika
        Debug.Log("Enemy died");
        float random = Random.value;
        if (random <= 0.25f)
            Spawnhp();
        else if (random <= 0.50f)
            Spawnmana();
        else
            Debug.Log("nic");
        Destroy(gameObject);

    }

    void Spawnmana()
    {
        Debug.Log("mana na ziemi");
        Instantiate(hpPrefab, transform.position, Quaternion.identity);
    }
    void Spawnhp()
    {
        Debug.Log("hp na ziemi");
        Instantiate(manaPrefab, transform.position, Quaternion.identity);
    }
}
