using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointandclick : MonoBehaviour
{
    private Vector3 destination;
    private int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
        if (Input.GetMouseButtonDown(0)) Move(); 
    }

    public void Move()
    {
        RaycastHit hit;
    }
}
