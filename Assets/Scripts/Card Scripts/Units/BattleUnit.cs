using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This represent the Player and Enemy Unit
During a battle
*/
public class BattleUnit : MonoBehaviour
{
    public string unitName;
    public int unitAttack;
    public int unitDefense;

    public int damage;
    public int damageMultiplier;

    public int maxHP;
    public int currentHP;

    private CardUnit cardUnit;

    private void Awake()
    {
        cardUnit = GetComponent<CardUnit>();
    }

    public void LoadNewCard(Card card)
    {
        cardUnit.LoadNewCard(card);
    }

    public void ResetCardToDefault()
    {
        cardUnit.UnloadCurrentCard();
    }

    public Card GetCard()
    {
        return cardUnit.card;
    }

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }
}