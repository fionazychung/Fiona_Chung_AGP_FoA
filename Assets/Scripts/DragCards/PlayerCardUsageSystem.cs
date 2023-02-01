using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCardUsageSystem : MonoBehaviour
{
    [SerializeField]
    private PlayerHandZone playerHand;
    public HandCardDisplay selectedCard;
    public CardDisplay cardDisplay;
    public HandCardDisplay [] hand;
    public Button turnButton;

    public bool inGame = true;
    public bool cardHasLeftPlayerHandZone = false;


    private void Start()
    {
        if (inGame)
        {
            for (int i = 0; i < 4; ++i)
            {
                List<Card> dataHand = GameData.instance.hand;
                if (dataHand[i] != null)
                {
                    //Debug.Log($"copy hand{i}");
                    hand[i].CopyCard(dataHand[i]);
                }
                else
                {
                    hand[i].gameObject.SetActive(false);
                }
            }
        }
    }

    public void PlayCard()
    {
        if (cardHasLeftPlayerHandZone)
        {
            cardDisplay.CopyCard(selectedCard.card);
            turnButton.interactable = true;
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
                    //GameObject.Find("Canvas").GetComponent<Canvas>().transform.Find("TurnCountdownPanel").gameObject.SetActive(false);
                    card.turnCountdownText.text = "";
                }
                else
                {
                    card.turnCountdownText.text = card.countdownNo.ToString();
                    //GameObject.Find("Canvas").GetComponent<Canvas>().transform.Find("TurnCountdownPanel").gameObject.SetActive(true);
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

    internal void CopyCard(Card card, HandCardDisplay handCard)
    {
        if (handCard != null)
        {
            for (int i = 0; i < GameData.instance.hand.Count; i++)
            {
                if (GameData.instance.hand[i] == card)
                    return;
            }

            handCard.CopyCard(card);

            int index = Array.IndexOf(hand, handCard);
            GameData.instance.hand[index] = card;
        }
    }
}
