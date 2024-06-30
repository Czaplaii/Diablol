using System.Collections.Generic;
using UnityEngine;

public class eksplozja : MonoBehaviour
{
    [SerializeField] CharacterStats staty;
    private ParticleSystem particleSystem;
    private HashSet<Collider> damagedEnemies;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        damagedEnemies = new HashSet<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy") && !damagedEnemies.Contains(other))
        {
            Enemy_AI enemystats = other.GetComponent<Enemy_AI>();
            if (enemystats != null)
            {
                enemystats.TakeDamage(staty.explosiondmg);
                damagedEnemies.Add(other);
            }
        }
        else if(other.CompareTag("boss") && !damagedEnemies.Contains(other))
        {
            Boss enemystats = other.GetComponent<Boss>();
            if (enemystats != null)
            {
                enemystats.TakeDamage(staty.explosiondmg / 1.5f);
                damagedEnemies.Add(other);
            }
        }
    }

}
