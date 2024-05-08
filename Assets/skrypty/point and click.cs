using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pointandclick : MonoBehaviour
{
    private Vector3 targetPosition;
    private int speed = 5;
    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);

        if (Input.GetMouseButtonDown(0)) Move();
    }

    void Move()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            targetPosition = hit.point + new Vector3(0, 0.5f, 0);
        }
    }
}
