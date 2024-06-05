using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_stats : MonoBehaviour
{
    public Image HpBar, ManaBar;
    [SerializeField] CharacterStats staty;
    public Image skill1, skill2, skill3, skill4;

    void Start()
    {
        staty = FindObjectOfType<CharacterStats>();
    }

    void Update()
    {
        UiUpdate();
    }

    void UiUpdate()
    {
        //HpBar.fillAmount = staty.hp / 100f;

        //ManaBar.fillAmount = staty.mana / 100f;
    }
    public void Qclick()
    {
        skill1.fillAmount = 1f;
        skill1.fillAmount = 5f / 100f;
    }
}
