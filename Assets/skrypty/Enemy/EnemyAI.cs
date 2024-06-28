using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int currentPatrolIndex;
    public float speed = 2f;
    public float detectionRange = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f; // Co 2 sekundy
    private float nextFireTime;
    private Transform player;

    private bool isPlayerInSight;
    private Vector3 lastKnownPlayerPosition;

    void Start()
    {
        currentPatrolIndex = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Patrol();
        DetectPlayer();
        Shoot();
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0)
            return;

        Transform targetPatrolPoint = patrolPoints[currentPatrolIndex];
        Vector3 direction = (targetPatrolPoint.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPatrolPoint.position) < 0.5f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
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
            FireBullet(lastKnownPlayerPosition);
        }
        else
        {
            FireBullet(lastKnownPlayerPosition);
        }
    }

    void FireBullet(Vector3 targetPosition)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (targetPosition - firePoint.position).normalized;
            rb.velocity = direction * 10f; // Prêdkoœæ kuli, dostosuj wed³ug potrzeby
        }
    }
}
