using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class pointandclick : MonoBehaviour
{
    private NavMeshAgent agent;
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

    bool movement;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MovementEnable(true);
        uiUpdate = FindObjectOfType<UI_stats>();
    }

    void Update()
    {
        if (movement)
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

    public void MovementEnable(bool a)
    {
        movement = a;
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
