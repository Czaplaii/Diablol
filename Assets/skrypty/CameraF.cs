using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraF : MonoBehaviour
{
    [Header("Target")]
    public Transform Player;
    [Header("Distance")]
    [Range(2f, 10f)]public float distance = 5f;
    public float minDistance = 1f;
    public float maxDistance = 7f;
    public Vector3 offset;
    [Header("Speed")]
    public float smoothSpeed = 5f;
    public float scrollSensitivity = 1;


    // Start is called before the first frame update https://www.youtube.com/watch?v=Eyga3DzFZo8
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Check if scroll is not blocked due to min or max distance
        if (!(scrollInput < 0f && distance <= minDistance) && !(scrollInput > 0f && distance >= maxDistance))
        {
            distance -= scrollInput * scrollSensitivity;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);

            Vector3 pos = transform.position + offset;

            // Adjust position based on scroll input
            if (scrollInput < 0f)
                pos -= transform.forward * distance;
            else if (scrollInput > 0f)
                pos += transform.forward * distance;

            transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed * Time.deltaTime);
        }
    }
}
