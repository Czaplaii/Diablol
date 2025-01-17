using System.Collections;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] CharacterStats staty;
    // Start is called before the first frame update
    void Start()
    {
        staty.mana = staty.maxmana;
        StartCoroutine(Regen());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Regen()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            if (staty.mana < staty.maxmana)
            {
                staty.mana += 1;
                if (staty.mana > staty.maxmana)
                {
                    staty.mana = staty.maxmana;
                }
            }
        }
    }
}
    