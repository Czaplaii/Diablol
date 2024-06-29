using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dexweapon : MonoBehaviour
{
    [SerializeField] CharacterStats staty;
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
        if (other.CompareTag("enemy"))
        {
            Enemy_AI enemystats = other.GetComponent<Enemy_AI>();
            Debug.Log("tag sprawdzony");
            enemystats.TakeDamage(staty.aadmgdex);
            Debug.Log("skrypt dzia�a");
        }
    }


}
