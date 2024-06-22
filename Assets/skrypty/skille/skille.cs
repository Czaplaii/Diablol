using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class skille : MonoBehaviour
{
    [SerializeField]GameObject window;
    [SerializeField]GameObject[] list;
    [SerializeField]Text text;
    [SerializeField]Text strvalue, dexvalue, intvalue, endvalue, wisvalue;
    string convertstr,convertdex,convertint,convertend,convertwis;
    [SerializeField]Button[] guzik;
    bool[] skillunlocked = {false, false, false, false, false };
    public CharacterStats characterStats;
    [SerializeField] GameObject[] roots;
    [SerializeField] GameObject buttons;



    // Start is called before the first frame update
    void Start()
    {
        characterStats.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        string convertxt = characterStats.skillpoint.ToString();
        text.text = (convertxt);
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("klik");
            if (window.activeSelf)
            {
                window.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1f;
            }
            else 
            { 
                window.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                Time.timeScale = 0.1f;
            }
        }

        if(Input.GetKeyDown(KeyCode.Z)) 
        {
            characterStats.skillpointy(1);
        }

        if (characterStats.skillpoint > 0)
        {
            buttons.SetActive(true);
        }
        else
        {
            buttons.SetActive(false);
        }
    convertstr = characterStats.strength.ToString();
    strvalue.text=convertstr;
        convertdex = characterStats.dexterity.ToString();
        dexvalue.text = convertdex;
        convertint = characterStats.inteligence.ToString();
        intvalue.text = convertint;
        convertend = characterStats.endurance.ToString();
        endvalue.text = convertend;
        convertwis = characterStats.wisdom.ToString();
        wisvalue.text = convertwis;
    }



//opisy skilli

    public void opis1()
    {
        for (int i = 0; i < list.Length; i++)
        {
            list[i].SetActive(false);
        }
        list[0].SetActive(true);
    }

    public void opis2()
    {
        for (int i = 0; i < list.Length; i++)
        {
            list[i].SetActive(false);
        }
        list[1].SetActive(true);
    }

    public void opis3()
    {
        for (int i = 0; i < list.Length; i++)
        {
            list[i].SetActive(false);
        }
        list[2].SetActive(true);
    }

    public void opis4()
    {
        for (int i = 0; i < list.Length; i++)
        {
            list[i].SetActive(false);
        }
        list[3].SetActive(true);
    }

    public void opis5()
    {
        for (int i = 0; i < list.Length; i++)
        {
            list[i].SetActive(false);
        }
        list[4].SetActive(true);
    }

    public void opis6()
    {
        for (int i = 0; i < list.Length; i++)
        {
            list[i].SetActive(false);
        }
        list[5].SetActive(true);
    }

    //skille
    public void skill1()
    {
        if (characterStats.skillpoint > 0)
        {
            characterStats.bonusms(2f);
            guzik[0].interactable = false;
            characterStats.skillpointy(-1);
            skillunlocked[0] = true;
            roots[0].SetActive(true);
        }
    }

    public void skill2()
    {
        if (characterStats.skillpoint > 0 && skillunlocked[0])
        {
            characterStats.bonusms(2f);
            guzik[1].interactable = false;
            characterStats.skillpointy(-1);
            skillunlocked[1] = true;
            skillunlocked[2] = true;
            roots[1].SetActive(true);
            roots[2].SetActive(true);
        }
    }

    public void skill3()
    {
        if (characterStats.skillpoint > 0 && skillunlocked[1])
        {
            characterStats.bonusdmg();
            guzik[2].interactable = false;
            characterStats.skillpointy(-1);
            skillunlocked[3] = true;
            roots[3].SetActive(true);
        }
    }

    public void skill4()
    {
        if (characterStats.skillpoint > 0 && skillunlocked[2])
        {
            guzik[3].interactable = false;
            characterStats.skillpointy(-1);
        }
    }

    public void skill5()
    {
        if (characterStats.skillpoint > 0 && skillunlocked[3])
        {
            characterStats.doublehp();
            guzik[4].interactable = false;
            characterStats.skillpointy(-1);
            roots[3].SetActive(true);
            skillunlocked[4] = true;
        }
    }

    public void skill6()
    {
        if (characterStats.skillpoint > 0 && skillunlocked[4])
        {
            characterStats.doubledmg();
            guzik[5].interactable = false;
            characterStats.skillpointy(-1);
        }
    }

    public void rawstat1()
    {
        characterStats.bonustr();
    }

    public void rawstat2()
    {
        characterStats.bonusdex();
    }
    public void rawstat3()
    {
        characterStats.bonusint();
    }
    public void rawstat4()
    {
        characterStats.bonusend();
    }
}
