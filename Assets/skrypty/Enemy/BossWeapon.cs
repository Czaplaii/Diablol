using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    [SerializeField]CharacterStats characterStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            characterStats.hp -= 20;
            //DMG();
        }
    }
    IEnumerator DMG()
    {
        yield return new WaitForSeconds(2.4f);
        characterStats.hp -= 20;
    }
}
