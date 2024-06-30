using UnityEngine;
using System.Collections.Generic;

public class LvlManager : MonoBehaviour
{
    [SerializeField] GameObject[] initialEnemies;
    [SerializeField] GameObject newEnemy1, newEnemy2;

    private List<GameObject> enemies;

    void Start()
    {
        enemies = new List<GameObject>(initialEnemies);
    }

    void Update()
    {
        CheckEnemiesStatus();
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
            SpawnNewEnemies();
        }
    }

    void SpawnNewEnemies()
    {
        if (newEnemy1 != null)
        {
            newEnemy1.SetActive(true);
            enemies.Add(newEnemy1);
        }

        if (newEnemy2 != null)
        {
            newEnemy2.SetActive(true);
            enemies.Add(newEnemy2);
        }
    }
}
