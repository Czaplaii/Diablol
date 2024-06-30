using System.Collections;
using UnityEngine;

public class creditseaster : MonoBehaviour
{
    [SerializeField] GameObject forearm1;
    [SerializeField] GameObject forearm2;
    [SerializeField] GameObject forearm3;

    void Start()
    {
        StartCoroutine(ChangeForearmRotation());
    }

    void Update()
    {
    }

    IEnumerator ChangeForearmRotation()
    {
        // Create an array to easily access and randomly choose a forearm
        GameObject[] forearms = { forearm1, forearm2, forearm3 };

        while (true)
        {
            yield return new WaitForSeconds(1f);
            int randomIndex = Random.Range(0, forearms.Length);
            GameObject lapa = forearms[randomIndex];
            lapa.transform.Rotate(65,0, 0) ;
            StartCoroutine(RotateBackAfterDelay(lapa));
            yield return new WaitForSeconds(4f);
        }
    }

    IEnumerator RotateBackAfterDelay(GameObject forearm)
    {
        yield return new WaitForSeconds(2f);
        forearm.transform.Rotate(-65, 0, 0);
    }
}
