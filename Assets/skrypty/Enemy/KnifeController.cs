using System.Collections;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    [SerializeField] CharacterStats staty;

    bool hasDamaged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !hasDamaged)
        {
            hasDamaged = true;
            StartCoroutine(DamagePlayerOverTime(other.gameObject));
        }
    }

    IEnumerator DamagePlayerOverTime(GameObject player)
    {
        staty.hp -= staty.knife;
        yield return new WaitForSeconds(0.5f);

        hasDamaged = false;
    }
}
