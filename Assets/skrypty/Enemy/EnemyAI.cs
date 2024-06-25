using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] patrolPoints;
    private int currentPatrolIndex;
    private Transform player;
    public float detectionRange = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    private float nextFireTime;

    private bool isPlayerInSight;
    private Vector3 lastKnownPlayerPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentPatrolIndex = 0;
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
    }

    void Update()
    {
        Patrol();
        DetectPlayer();
        Shoot();
    }

    void Patrol()
    {
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }

    void DetectPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRange)
        {
            isPlayerInSight = true;
            lastKnownPlayerPosition = player.position;
        }
        else
        {
            isPlayerInSight = false;
        }
    }

    void Shoot()
    {
        if (isPlayerInSight && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            StartCoroutine(FireAfterDelay(2f));
        }
    }

    IEnumerator FireAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (isPlayerInSight)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(lastKnownPlayerPosition - firePoint.position));
        }
        else
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(lastKnownPlayerPosition - firePoint.position));
        }
    }
}
