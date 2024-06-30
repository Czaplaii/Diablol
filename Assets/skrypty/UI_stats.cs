using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_stats : MonoBehaviour
{
    public Image HpBar, ManaBar;
    [SerializeField] CharacterStats staty;
    public Image skill1, skill2, skill3, skill4;

    void Start()
    {
        //staty = FindObjectOfType<CharacterStats>();
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
        StartCoroutine(Cooldown(skill1,staty.cooldownq));
    }

    public void Wclick()
    {
        StartCoroutine(Cooldown(skill2, staty.cooldownw));
    }

    public void Eclick()
    {
        StartCoroutine(Cooldown(skill3, staty.cooldowne));
    }

    public void Rclick()
    {
        StartCoroutine(Cooldown(skill4, staty.cooldownr));
    }

    IEnumerator Cooldown(Image skill, float cd)
    {
        float elapsedTime = 0f;

        skill.fillAmount = 1f;

        while (elapsedTime < cd)
        {
            elapsedTime += Time.deltaTime;
            skill.fillAmount = Mathf.Lerp(1f, 0f, elapsedTime / cd);
            yield return null;
        }
    }
}