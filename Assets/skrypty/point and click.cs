using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointandclick : MonoBehaviour
{
    public GameObject clickEffectPrefab;
    public float effectLifetime = 3.0f;

    private Vector3 targetPosition;
    private int speed = 5;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Move(out hit);
            PlayClickEffect(hit);
        }
    }

    void Move(out RaycastHit hit)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            targetPosition = hit.point + new Vector3(0, 0.5f, 0);
        }
    }

    void PlayClickEffect(RaycastHit hit)
    {
        if (clickEffectPrefab != null)
        {
            Vector3 clickPosition = hit.point;
            clickPosition.z = 0;
            GameObject effect = Instantiate(clickEffectPrefab, clickPosition, Quaternion.identity);
            Rigidbody rb = effect.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.up * 5f;
            }
            Destroy(effect, effectLifetime);
        }
    }
}
