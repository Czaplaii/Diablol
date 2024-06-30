using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dexweapon : MonoBehaviour
{
    [SerializeField] CharacterStats staty;
    [SerializeField] ChangeGun weapon;
    GameObject currentWeapon;
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
        currentWeapon = weapon.GetWeapon();
        Debug.Log(currentWeapon.name);
        Debug.Log("JEST W TRIGERZE");
        if (other.CompareTag("enemy"))
        {
            Debug.Log("weszlo w enemy");
            if (currentWeapon.name == "Miecz")
            {
                Enemy_AI enemystats = other.GetComponent<Enemy_AI>();
                Debug.Log("tag sprawdzony");
                enemystats.TakeDamage(staty.aadmgdex);
                Debug.Log("skrypt dzia�a");
            }
            else if (currentWeapon.name == "Topor")
            {
                Debug.Log("TOPOR ZADAJE OBRAZENIA");
                Enemy_AI enemystats = other.GetComponent<Enemy_AI>();
                Debug.Log("tag sprawdzony");
                enemystats.TakeDamage(staty.aadmgstr);
                Debug.Log("skrypt dzia�a");
            }
        }
        else if (other.CompareTag("boss"))
        {
            if (currentWeapon.name == "Miecz")
            {
                Boss enemystats = other.GetComponent<Boss>();
                Debug.Log("tag sprawdzony");
                enemystats.TakeDamage(staty.aadmgdex / 1.5f);
                Debug.Log("skrypt dzia�a");
            }else if (currentWeapon.name == "Topor")
            {
                Boss enemystats = other.GetComponent<Boss>();
                Debug.Log("tag sprawdzony");
                enemystats.TakeDamage(staty.aadmgstr / 1.5f);
                Debug.Log("skrypt dzia�a");
            }
        }
    }


}
