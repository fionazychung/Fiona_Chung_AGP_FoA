using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelection : MonoBehaviour
{
    [SerializeField]
    private PlayerHandZone playerHand;
    public CardDisplay selectedCard;
    public HandCardDisplay handCardDisplay;
    public HandCardDisplay [] hand;

    public bool cardHasLeftDeckZone = false;

    public void PickCard()
    {
        if (cardHasLeftDeckZone)
        {
            handCardDisplay.CopyCard(selectedCard.card);
        }
    }
}
