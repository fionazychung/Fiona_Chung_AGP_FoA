using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardUsageSystem : MonoBehaviour
{
    [SerializeField]
    private PlayerHandZone playerHand;
    public HandCardDisplay selectedCard;
    public CardDisplay cardDisplay;
    public HandCardDisplay [] hand;

    public bool cardHasLeftPlayerHandZone = false;

    public void PlayCard()
    {
        if (cardHasLeftPlayerHandZone)
        {
            cardDisplay.CopyCard(selectedCard.card);

        }
    }


    public void CardCountdown()
    {
        foreach (HandCardDisplay card in hand)
        {
            if (card.countdownNo > 0)
            {
                card.countdownNo--;
                if (card.countdownNo == 0)
                {
                    card.GetComponent<CanvasGroup>().interactable = true;
                    card.turnCountdownText.text = "";
                }
                else
                {
                    card.turnCountdownText.text = card.countdownNo.ToString();
                }
            }
        }
    }

    internal void EndTurn()
    {
        CardCountdown();
        selectedCard.CopyTurnNo();
        // remove the current scriptable card data from the player card
    }
}
