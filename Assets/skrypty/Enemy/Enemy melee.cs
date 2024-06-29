using System.Collections;
using UnityEngine;

public class Enemymelee : MonoBehaviour
{
    [SerializeField] BoxCollider box;
    [SerializeField] Animator noz;
    [SerializeField] float attackDuration = 2.4f;

    public void Knife()
    {
        box.enabled = true;
        noz.SetBool("Attack", true);
        StartCoroutine(DisableColliderAfterAttack());
    }

    private IEnumerator DisableColliderAfterAttack()
    {
        yield return new WaitForSeconds(attackDuration);
        box.enabled = false;
        noz.SetBool("Attack", false);
    }
}
