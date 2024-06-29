using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] CharacterStats staty;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DamagePlayerOverTime(other.gameObject));
        }
    }

    IEnumerator DamagePlayerOverTime(GameObject player)
    {
        for (int i = 0; i < 5; i++)
        {
            staty.hp -= staty.bullet;
            yield return new WaitForSeconds(0.5f);
        }
    }
}