using UnityEngine;

public class Enemyshoot : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject spawnBullet;
    [SerializeField] Transform player;

    public void Shoot()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        Rigidbody rb = Instantiate(projectile, spawnBullet.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(direction * 20f, ForceMode.Impulse);
        rb.AddForce(transform.up * 3f, ForceMode.Impulse);
    }
}
