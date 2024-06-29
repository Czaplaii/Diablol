using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class pointandclick : MonoBehaviour
{
    [SerializeField] CharacterStats staty;
    private NavMeshAgent agent;
    private Animator animator;
    bool cd = true;
    [SerializeField]int manacostq= 30;
    bool cd2 = true;
    [SerializeField]int manacostw = 50;
    bool cd3 = true;
    [SerializeField]int manacoste = 10;
    bool cd4 = true;
    [SerializeField] int manacostr = 80;
   [SerializeField] GameObject fireballprefab;
    [SerializeField] UI_stats uiUpdate;
    public float fireballSpeed = 10f;
    public float spawnDistance = 1.5f;
    [SerializeField] GameObject implosion;
    Vector2 SmoothDeltaPosition;
    Vector2 velocity;

    bool AttackDone;
    [SerializeField] ParticleSystem healPrefab;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = staty.moveSpeed;

        agent.acceleration = 27f;
        agent.angularSpeed = 720f;
        agent.stoppingDistance = 0.1f;

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
        Mana magia;
        magia = GetComponent<Mana>();

        //czy moge skilla u¿yæ
        int q = PlayerPrefs.GetInt("qskill");
        int w = PlayerPrefs.GetInt("wskill");
        int e = PlayerPrefs.GetInt("eskill");
        int r = PlayerPrefs.GetInt("rskill");

        //przyciski
        if (MovementController.Instance.IsMovementEnabled())
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Move(out hit);
            }


            if (Input.GetKey(KeyCode.Q) && cd && staty.mana>manacostq && q == 1)
            {
                cd = false;
                StartCoroutine(CooldownRoutine1());
                uiUpdate.Qclick();
                staty.mana -= manacostq;
                LaunchFireball();
            }

            if (Input.GetKey(KeyCode.W) && cd2 && staty.mana > manacostw && w == 1)
            {
                cd2 = false;
                StartCoroutine(CooldownRoutine2());
                uiUpdate.Wclick();
                LaunchShield();
                staty.mana -= manacostw;
            }

            if (Input.GetKey(KeyCode.E) && cd3 && staty.mana > manacoste && e == 1)
            {
                cd3 = false;
                StartCoroutine(CooldownRoutine3());
                uiUpdate.Eclick();
                LaunchTp();
                staty.mana -= manacoste;
            }

            if (Input.GetKey(KeyCode.R) && cd4 && staty.mana > manacostr && r == 1)
            {
                cd4 = false;
                StartCoroutine(CooldownRoutine4());
                uiUpdate.Rclick();
                LaunchAoe();
                staty.mana -= manacostr ;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AutoAttack();
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

        float smooth = Mathf.Min(1, Time.deltaTime / 0.1f);
        SmoothDeltaPosition = Vector2.Lerp(SmoothDeltaPosition, deltaPosition, smooth);

        velocity = SmoothDeltaPosition / Time.deltaTime;
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            velocity = Vector2.Lerp(
                Vector2.zero, 
                velocity, 
                agent.remainingDistance / agent.stoppingDistance);
        }

        bool shouldMove = velocity.magnitude > 0.2f && agent.remainingDistance > agent.stoppingDistance;

        

        animator.SetBool("move", shouldMove);
        animator.SetFloat("locomotion", velocity.magnitude);
        float deltaMagnitude = worldDeltaPosition.magnitude;
        if(deltaMagnitude > agent.radius / 3) 
        {
            transform.position = Vector3.Lerp(
                animator.rootPosition,
                agent.nextPosition,
                smooth);
        }
    }

    private IEnumerator CooldownRoutine1()
    {
        yield return new WaitForSeconds(staty.cooldownq);
        cd = true;
    }

    private IEnumerator CooldownRoutine2()
    {
        yield return new WaitForSeconds(staty.cooldownw);
        cd2 = true;
    }

    private IEnumerator CooldownRoutine3()
    {
        yield return new WaitForSeconds(staty.cooldowne);
        cd3 = true;
    }

    private IEnumerator CooldownRoutine4()
    {
        yield return new WaitForSeconds(staty.cooldownr);
        cd4 = true;
    }
    void LaunchFireball()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point;
            Vector3 direction = new Vector3(targetPosition.x - transform.position.x, 0, targetPosition.z - transform.position.z).normalized;
            Vector3 spawnPosition = transform.position + direction * spawnDistance;
            spawnPosition.y +=3f;
            GameObject fireball = Instantiate(fireballprefab, spawnPosition, Quaternion.identity);
            kulaognia fireballz = fireball.GetComponent<kulaognia>();
            Vector3 adjustedTargetPosition = new Vector3(targetPosition.x, spawnPosition.y, targetPosition.z);
            fireballz.SetDirection(adjustedTargetPosition);
            fireballz.speed = fireballSpeed;
        }
    }

    void LaunchShield()
    {
        Vector3 agentPosition = agent.transform.position;
        agentPosition.y = 0;
        hp zdrowie;
        zdrowie = GetComponent<hp>();
        int increaseAmount = Mathf.RoundToInt(staty.maxhp * 0.5f);
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Cast heal"))
        {
            animator.StopPlayback();
            SetHealDone(false);
            animator.SetTrigger("Heal");
            Instantiate(healPrefab, agentPosition, Quaternion.identity);
            Debug.Log("Posz³o info");
            SetHealDone(true);
        }
            staty.hp  += increaseAmount;
        if (staty.hp > staty.maxhp)
        {
            staty.hp = staty.maxhp;
        }
        Debug.Log("Zwiêkszono zdrowie o " + increaseAmount + ". Nowe zdrowie: " + staty.hp);
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
        implosion.SetActive(true);
        Invoke("AoeOff", 1);
    }

    void AoeOff()
    {
        implosion.SetActive(false);
    }
    void AutoAttack()
    {
        //bool autoAttack = animator.Get;
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
            animator.StopPlayback();
            SetAttackDone(false);
            Debug.Log("ATAK");
            animator.SetTrigger("AutoAttack");

            SetAttackDone(true);
        }
    }

    void SetAttackDone(bool value)
    {
        animator.SetBool("AttackDone", value);
    }
    
    void SetHealDone(bool value)
    {
        animator.SetBool("Heal", value);
    }
}
