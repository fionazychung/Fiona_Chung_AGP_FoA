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
    public CardDisplay DeckCardPrefab;
    public PlayerCardUsageSystem playerCardUsage;

    public bool cardHasLeftDeckZone = false;

    private void Start()
    {
        foreach (Card card in GameData.instance.deck)
        {
            CardDisplay cardDisplay = Instantiate(DeckCardPrefab, transform);
            cardDisplay.CopyCard(card);
            DraggableCard draggableCard = cardDisplay.GetComponent<DraggableCard>();
            draggableCard.playerCardSystem = playerCardUsage;
        }

    }

    public void PickCard()
    {
        if (cardHasLeftDeckZone)
        {
            handCardDisplay.CopyCard(selectedCard.card);
        }
    }
}
