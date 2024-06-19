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
        if(Input.GetKeyDown(KeyCode.Z))
        {
            staty.hp -= 10;
            staty.mana -= 10;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            staty.hp += 10;
            staty.mana += 10;
        }
    }

    void UiUpdate()
    {
        HpBar.fillAmount = staty.hp / 100f;

        ManaBar.fillAmount = staty.mana / 100f;
    }
    public void Qclick()
    {
        StartCoroutine(Cooldown(skill1));
    }

    public void Wclick()
    {
        StartCoroutine(Cooldown(skill2));
    }

    public void Eclick()
    {
        StartCoroutine(Cooldown(skill3));
    }

    public void Rclick()
    {
        StartCoroutine(Cooldown(skill4));
    }

    IEnumerator Cooldown(Image skill)
    {
        float cooldownTime = 5f;
        float elapsedTime = 0f;

        skill.fillAmount = 1f;

        while (elapsedTime < cooldownTime)
        {
            elapsedTime += Time.deltaTime;
            skill.fillAmount = Mathf.Lerp(1f, 0f, elapsedTime / cooldownTime);
            yield return null;
        }
    }
}