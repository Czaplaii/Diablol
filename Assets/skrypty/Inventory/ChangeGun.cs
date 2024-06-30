using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGun : MonoBehaviour
{
    public GameObject inventory;
    public List<GameObject> weapons = new List<GameObject>(new GameObject[3]); 

    GameObject currentGun;

    private pointandclick move;

    // Start is called before the first frame update
    void Start()
    {
        inventory.SetActive(false);
        move = GetComponent<pointandclick>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventory.SetActive(true);
            MovementController.Instance.SetMovementEnabled(false);
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            inventory.SetActive(false);
            MovementController.Instance.SetMovementEnabled(true);
        }
    }

    public void SelectWeapon(int choice)
    {
        if (currentGun != null)
        {
            currentGun.SetActive(false);
        }

        currentGun = weapons[choice];
        if (currentGun != null)
        {
            currentGun.SetActive(true);
        }
    }
    public GameObject GetWeapon()
    {
        return currentGun;
    }
}
