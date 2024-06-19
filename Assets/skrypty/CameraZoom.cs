using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    CinemachineComponentBase componentBase;
    float cameraDistance;

    [SerializeField] float sensitivity = 10f;
    [SerializeField] float minDistance = 10f;
    [SerializeField] float maxDistance = 25f;

    void Update()
    {
        if (componentBase == null)
        {
            componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            cameraDistance = Input.GetAxis("Mouse ScrollWheel") * sensitivity;

            if (componentBase is CinemachineFramingTransposer)
            {
                float newDistance = (componentBase as CinemachineFramingTransposer).m_CameraDistance - cameraDistance;
                newDistance = Mathf.Clamp(newDistance, minDistance, maxDistance);
                (componentBase as CinemachineFramingTransposer).m_CameraDistance = newDistance;
            }
        }
    }
}

