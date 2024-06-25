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
    [SerializeField] GameObject page1, page2;



    // Start is called before the first frame update
    void Start()
    {
        characterStats.Reset();
        PlayerPrefs.SetInt("currentpage", 1);
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
                Time.timeScale = 1f;
            }
            else 
            { 
                window.SetActive(true);
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
            characterStats.doublehp();
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
            PlayerPrefs.SetInt("qskill", 1);
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
            characterStats.doublemana();
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
            PlayerPrefs.SetInt("wskill", 1);
            guzik[3].interactable = false;
            characterStats.skillpointy(-1);
        }
    }

    public void skill5()
    {
        if (characterStats.skillpoint > 0 && skillunlocked[3])
        {
            PlayerPrefs.SetInt("eskill", 1);
            guzik[4].interactable = false;
            characterStats.skillpointy(-1);
            roots[5].SetActive(true);
            skillunlocked[4] = true;
        }
    }

    public void skill6()
    {
        if (characterStats.skillpoint > 0 && skillunlocked[4])
        {
            PlayerPrefs.SetInt("rskill", 1);
            guzik[5].interactable = false;
            characterStats.skillpointy(-1);
        }
    }

    //raw statystyki
    public void rawstat1()
    {
        characterStats.bonustr();
        characterStats.healthboost();
        characterStats.aadmgfromstr();
    }

    public void rawstat2()
    {
        characterStats.bonusdex();
        characterStats.aadmgfromdex();
    }
    public void rawstat4()
    {
        characterStats.bonusint();
        characterStats.manaboost();
    }
    public void rawstat3()
    {
        characterStats.bonusend();
        characterStats.healthboost();
    }

    public void rawstat5()
    {
        characterStats.bonuswis();
        characterStats.manaboost();
    }

    public void pager1()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        PlayerPrefs.SetInt("currentpage", 1);
    }

    public void pager2()
    {
        page1.SetActive(false);
        page2.SetActive(true);
        PlayerPrefs.SetInt("currentpage", 2);
    } 
}
