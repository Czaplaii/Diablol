using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "Character/Stats")]
public class CharacterStats : ScriptableObject
{
    public float moveSpeed = 10f; // Prêdkoœæ ruchu
    //public int damage = 10; // Obra¿enia
    public int maxhp = 100;
    public int hp = 100;
    public int mana = 100;
    public int maxmana = 100;
    public bool jumplock = true;
    public int skillpoint = 0;
    //raw stats
    public int strength = 10;
    public int dexterity = 10;
    public int endurance = 10;
    public int inteligence = 10;
    public int wisdom = 10;
    //cooldowns
    public float cooldownq = 5f;
    public float cooldownw = 10f;
    public float cooldowne = 30f;
    public float cooldownr = 45f;
    //true damage
    public double fireballdmg = 30;
    public double explosiondmg = 60;
    public double aadmgstr = 20;
    public double aadmgdex = 15;

    public void bonusms(float ilosc)
    {
        moveSpeed += ilosc;
        Debug.Log("New move speed: " + moveSpeed);
    }

    public void doublehp()
    {
        hp += 50 ;
        maxhp += 50;
    }
    public void doublemana()
    {
        mana += 50;
        maxmana += 50;
    }

    public void skillpointy(int ilosc)
    {
        skillpoint+=ilosc;
        Debug.Log("New skillpoint: " + skillpoint);
    }

    public void Reset()
    {
    moveSpeed = 10f; // Prêdkoœæ ruchu
   // damage = 10; // Obra¿enia
    skillpoint = 0;
    strength = 10;
    dexterity = 10;
    endurance = 10;
    inteligence = 10;
    wisdom = 10;
    mana = 100;
    maxmana = 100;
    hp = 100;
    maxhp = 100;
    fireballdmg = 30;
    explosiondmg = 60;
    aadmgstr = 20;
    aadmgdex = 15;
}

    public void bonustr()
    {
        strength++;
        skillpoint--;
    }
    public void bonusdex()
    {
        dexterity++;
        skillpoint--;
    }

    public void bonusint()
    {
        inteligence++;
        skillpoint--;
    }

    public void bonusend()
    {
        endurance++;
        skillpoint--;
    }
    public void bonuswis()
    {
        wisdom++;
        skillpoint--;
    }

    public void fbdmg()
    {
        fireballdmg = 30 + (inteligence * 1.2);
    }

    public void explodmg()
    {
        explosiondmg = 60 + (inteligence * 1.5);
    }

    public void aadmgfromstr()
    {
        aadmgstr = 20 + (strength * 0.8);
    }

    public void aadmgfromdex()
    {
        aadmgdex = 15 + (dexterity * 0.4);
    }

    public void healthboost()
    {
        maxhp = maxhp + (5 * (endurance - 10) + 2 * (strength - 10));
    }

    public void manaboost()
    {
        maxmana = maxmana + (5 * (wisdom - 10) + 2 * (inteligence - 10));
    }

    public void hprefill()
    {
        hp += 50;
    }

    public void manarefill()
    {
        mana += 50;
    }
} 