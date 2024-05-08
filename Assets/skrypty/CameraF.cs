using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraF : MonoBehaviour
{
    [Header("Target")]
    public Transform Player;
    [Header("Distance")]
    public float distance = 5f;
    public float minDistance = 1f;
    public float maxDistance = 7f;
    public Vector3 offset;
    [Header("Speed")]
    public float smoothSpeed = 5f;
    public float scrollSensitivity = 1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput < 0f && distance < 7)
        {
            distance -= scrollInput * scrollSensitivity;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);

            Vector3 pos = transform.position + offset;
            pos -= transform.forward * distance;

            transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed * Time.deltaTime);
        }
        else if (scrollInput > 0f && distance >1)
        {
            distance -= scrollInput * scrollSensitivity;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);

            Vector3 pos = transform.position + offset;
            pos += transform.forward * distance;

            transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed * Time.deltaTime);
        }


    }
}
