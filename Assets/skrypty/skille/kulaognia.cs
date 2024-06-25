using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kulaognia : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction;
    public float czaszycia = 3f;

    private void Start()
    {
        Destroy(gameObject, czaszycia);
    }

    public void SetDirection(Vector3 targetPosition)
    {
        direction = (targetPosition - transform.position).normalized;
    }

    void Update()
    {
        // Przesuwanie kuli ognia w zadanym kierunku
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    // Zdarzenie kolizji
    void OnCollisionEnter(Collision collision)
    {
        if ((collision.collider.CompareTag("enemy")))
        {
            //zadaj obra¿enia przeciwnikowi jak trafisz
        }
        // Zniszczenie kuli ognia po trafieniu w obiekt
        Destroy(gameObject);
    }
}
