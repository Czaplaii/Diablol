using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana_pickup : MonoBehaviour
{
    public float rotationSpeed = 100f; // Prêdkoœæ obrotu
    [SerializeField] int rodzaj; //hp - 1 , mana - 2
    [SerializeField] CharacterStats staty;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("w triggerze: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("tag sprawdzony");
            if (rodzaj == 1)
                staty.hprefill();
            else
                staty.manarefill();
            Debug.Log("skrypt dzia³a");
            Destroy(gameObject);
        }
    }
}
