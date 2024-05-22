using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "Character/Stats")]
public class CharacterStats : ScriptableObject
{
    public float moveSpeed = 10f; // Prêdkoœæ ruchu
    public int damage = 10; // Obra¿enia
    public int hp = 100;
    public bool jumplock = true;
    public int skillpoint = 0;
    //raw stats
    public int strength = 10;
    public int dexterity = 10;
    public int endurance = 10;
    public int inteligence = 10;


    public void bonusms(float ilosc)
    {
        moveSpeed += ilosc;
        Debug.Log("New move speed: " + moveSpeed);
    }

    public void bonusdmg()
    {
        damage = damage+ (damage/10);
        Debug.Log("New damage: " + damage);
    }
    public void doubledmg()
    {
        damage = 20;
    }

    public void doublehp()
    {
        hp = 200;
    }

    public void skillpointy(int ilosc)
    {
        skillpoint+=ilosc;
        Debug.Log("New skillpoint: " + skillpoint);
    }

    public void Reset()
    {
    moveSpeed = 10f; // Prêdkoœæ ruchu
    damage = 10; // Obra¿enia
    jumplock = true;
    skillpoint = 0;
    }

    public void jumpz()
    {
        jumplock = false;
        Debug.Log("mo¿esz skakaæ");
    }
} 