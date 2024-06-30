using UnityEngine;

public class kulaognia : MonoBehaviour
{
    [SerializeField] CharacterStats staty;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            Enemy_AI enemystats = other.GetComponent<Enemy_AI>();
            Debug.Log("tag sprawdzony");
            enemystats.TakeDamage(staty.fireballdmg);
            Debug.Log("skrypt dzia�a");
            Destroy(gameObject);
        }
        if (other.CompareTag("boss"))
        {
            Boss enemystats = other.GetComponent<Boss>();
            Debug.Log("tag sprawdzony");
            enemystats.TakeDamage(staty.fireballdmg / 1.5f);
            Debug.Log("skrypt dzia�a");
            Destroy(gameObject);
        }
    }
}
