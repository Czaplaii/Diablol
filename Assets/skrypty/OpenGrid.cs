using UnityEngine;

public class OpenGrid : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] Animator sezam;

    void Start()
    {
        sezam.enabled = false;
    }

    void Update()
    {
        CheckEnemiesStatus();
    }

    void OpenGate()
    {
        sezam.enabled = true;
        Invoke(nameof(Delay), 2f);
    }
    void Delay()
    {
        Destroy(gameObject);
    }
    void CheckEnemiesStatus()
    {
        bool allEnemiesDead = true;

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null && enemy.activeInHierarchy)
            {
                allEnemiesDead = false;
                break;
            }
        }

        if (allEnemiesDead)
        {
            OpenGate();
        }
    }
}
