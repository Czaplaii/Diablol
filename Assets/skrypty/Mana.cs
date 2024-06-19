using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mana : MonoBehaviour
{
    int maxmana = 100;
    public int mana = 100;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Regen());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("mana" + mana);

    }

    IEnumerator Regen()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            if (mana < maxmana)
            {
                mana += 1;
                if (mana > maxmana)
                {
                    mana = maxmana;
                }
            }
        }
    }
}
    