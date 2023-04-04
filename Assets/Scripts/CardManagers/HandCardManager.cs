using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandCardManager : MonoBehaviour
{
    [Header("CardUnits Reference")]
    [SerializeField] private List<CardUnit> cardUnits = new List<CardUnit>();

    private List<CardUnit> populatedHandCardUnit = new List<CardUnit>();

    public void SetCards()
    {
        //Todo Remove empty cards if less than 4 hands
        for (int i = 0; i < cardUnits.Count; i++)
        {
            if (GameData.instance.hand[i] != null)
            {
                cardUnits[i].LoadNewCard(GameData.instance.hand[i]);
                populatedHandCardUnit.Add(cardUnits[i]);
            }
        }
    }

    public void UpdateCardsTurn(CardUnit newUnitToAdd)
    {
        for (int i = 0; i < populatedHandCardUnit.Count; i++)
        {
            populatedHandCardUnit[i].UpdateTurn();
        }

        if (newUnitToAdd != null)
            newUnitToAdd.PlayCardThisTurn();
    }

    public bool HaveActiveCards()
    {
        for (int i = 0; i < populatedHandCardUnit.Count; i++)
        {
            if (populatedHandCardUnit[i].GetCurrentTurnCountdown() == 0)
                return true;
        }

        return false;
    }
}