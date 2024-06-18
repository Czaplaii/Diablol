using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class pointandclick : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private float cooldown = 5f;
    bool cd = true;
    private float cooldown2 = 5f;
    bool cd2 = true;
    private float cooldown3 = 5f;
    bool cd3 = true;
    private float cooldown4 = 5f;
    bool cd4 = true;
    [SerializeField] GameObject fireball;
    [SerializeField] UI_stats uiUpdate;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        animator.applyRootMotion = false;
        agent.updatePosition = false;
        agent.updateRotation = true;
    }

    private void OnAnimatorMove()
    {
        Vector3 rootPosition = animator.rootPosition;
        rootPosition.y = agent.nextPosition.y;
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
            }

            if (Input.GetKey(KeyCode.W) && cd2)
            {
                cd2 = false;
                StartCoroutine(CooldownRoutine2());
                uiUpdate.Wclick();
            }

            if (Input.GetKey(KeyCode.E) && cd3)
            {
                cd3 = false;
                StartCoroutine(CooldownRoutine3());
                uiUpdate.Eclick();
            }

            if (Input.GetKey(KeyCode.R) && cd4)
            {
                cd4 = false;
                StartCoroutine(CooldownRoutine4());
                uiUpdate.Rclick();
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

    private void OnParticleSystemStopped()
    {
        animator.SetBool("move", agent.velocity.magnitude > 0.5f);
        animator.SetFloat("locomotion", agent.velocity.magnitude);
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
}
