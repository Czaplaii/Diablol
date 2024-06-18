using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hp : MonoBehaviour
{
    public GameObject[] zdrowie;
    public int maxhealth = 100;
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            Invoke("ResetPoziomu",3);
        }
        Debug.Log("zdrowie" + health);
    }


    void ResetPoziomu()
    {
        //SceneManager.LoadScene(PlayerPrefs.GetInt("obecna"));
    }
}
