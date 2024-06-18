using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class pointandclick : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private float cooldown = 5f;
    bool cd = true;
    private float cooldown2 = 10f;
    bool cd2 = true;
    private float cooldown3 = 30f;
    bool cd3 = true;
    private float cooldown4 = 45f;
    bool cd4 = true;
    [SerializeField] GameObject fireballprefab;
    [SerializeField] UI_stats uiUpdate;
    public float fireballSpeed = 10f; // Prêdkoœæ kuli ognia
    public float spawnDistance = 1.5f;

    Vector2 SmoothDeltaPosition;
    Vector2 velocity;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        animator.applyRootMotion = false;
        agent.updatePosition = false;
        agent.updateRotation = true;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        uiUpdate = FindObjectOfType<UI_stats>();
    }

    void Update()
    {
        if (MovementController.Instance.IsMovementEnabled())
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Move(out hit);
            }

            if (Input.GetKey(KeyCode.Q) && cd)
            {
                cd = false;
                StartCoroutine(CooldownRoutine1());
                uiUpdate.Qclick();
                LaunchFireball();
            }

            if (Input.GetKey(KeyCode.W) && cd2)
            {
                cd2 = false;
                StartCoroutine(CooldownRoutine2());
                uiUpdate.Wclick();
                LaunchShield();
            }

            if (Input.GetKey(KeyCode.E) && cd3)
            {
                cd3 = false;
                StartCoroutine(CooldownRoutine3());
                uiUpdate.Eclick();
                LaunchTp();
            }

            if (Input.GetKey(KeyCode.R) && cd4)
            {
                cd4 = false;
                StartCoroutine(CooldownRoutine4());
                uiUpdate.Rclick();
                LaunchAoe();
            }
        }


    }

    void Move(out RaycastHit hit)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }

    private void OnAnimatorMove()
    {
        Vector3 worldDeltaPosition = agent.nextPosition - transform.position;
        worldDeltaPosition.y = 0;

        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

        float smooth = Mathf.Min(1, Time.deltaTime / 2);
        SmoothDeltaPosition = Vector2.Lerp(SmoothDeltaPosition, deltaPosition, smooth);

        velocity = SmoothDeltaPosition / Time.deltaTime;
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            velocity = Vector2.Lerp(
                Vector2.zero, 
                velocity, 
                agent.remainingDistance / agent.stoppingDistance);
        }

        bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.stoppingDistance;

        

        animator.SetBool("move", shouldMove);
        animator.SetFloat("locomotion", velocity.magnitude);
        float deltaMagnitude = worldDeltaPosition.magnitude;
        if(deltaMagnitude > agent.radius / 2) 
        {
            transform.position = Vector3.Lerp(
                animator.rootPosition,
                agent.nextPosition,
                smooth);
        }
    }

    private IEnumerator CooldownRoutine1()
    {
        yield return new WaitForSeconds(cooldown);
        cd = true;
    }

    private IEnumerator CooldownRoutine2()
    {
        yield return new WaitForSeconds(cooldown2);
        cd2 = true;
    }

    private IEnumerator CooldownRoutine3()
    {
        yield return new WaitForSeconds(cooldown3);
        cd3 = true;
    }

    private IEnumerator CooldownRoutine4()
    {
        yield return new WaitForSeconds(cooldown4);
        cd4 = true;
    }
    void LaunchFireball()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point;
            Vector3 direction = (targetPosition - transform.position).normalized;
            Vector3 spawnPosition = transform.position + direction * spawnDistance;
            GameObject fireball = Instantiate(fireballprefab, spawnPosition, Quaternion.identity);
            kulaognia fireballz = fireball.GetComponent<kulaognia>();
            if (fireballz != null)
            {
                fireballz.SetDirection(targetPosition);
                fireballz.speed = fireballSpeed;
            }
        }
    }

    void LaunchShield()
    {
        hp zdrowie;
        zdrowie = GetComponent<hp>();
        int increaseAmount = Mathf.RoundToInt(zdrowie.maxhealth * 0.5f);
        // Dodaj do health
        zdrowie.health += increaseAmount;
        // SprawdŸ czy health nie przekroczy³ maxhealth
        if (zdrowie.health > zdrowie.maxhealth)
        {
            zdrowie.health = zdrowie.maxhealth;
        }
        // Debugowe informacje
        Debug.Log("Zwiêkszono zdrowie o " + increaseAmount + ". Nowe zdrowie: " + zdrowie.health);
    }

    void LaunchTp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            NavMeshHit navHit;
            if (NavMesh.SamplePosition(hit.point, out navHit, 0.1f, NavMesh.AllAreas))
            {
                agent.Warp(navHit.position);
            }
        }
    }

    void LaunchAoe()
    {

    }
}
