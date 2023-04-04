using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum CardUnitType {Deck, HandSelection, HandGame, BattleUnit}

/*
Represent behavior for a single Card placed in the world,
such as deck, hand, or combat area
*/
[RequireComponent(typeof(CardDisplay))]
public class CardUnit : MonoBehaviour
{
    public Card card;
    public CardUnitType cardType;

    private CardDisplay cardDisplay;
    private CombatSystem combatSystem;

    private int currentTurn = 0;

    private void Awake()
    {
        cardDisplay = GetComponent<CardDisplay>();
    }

    void Start()
    {
        if (card != null)
            cardDisplay.CopyCard(card);

        combatSystem = FindObjectOfType<CombatSystem>();
    }

    //---------------------------------
    //* Loading and Unloading Card Data

    public void LoadNewCard(Card newCard)
    {
        card = newCard;
        cardDisplay.CopyCard(card);

        if (cardType == CardUnitType.HandSelection)
            cardDisplay.ShowRemoveButton();
    }

    public void UnloadCurrentCard()
    {
        card = null;
        cardDisplay.RemoveCard();

        if (cardType == CardUnitType.HandSelection)
            cardDisplay.HideRemoveButton();
    }

    //---------------------------------
    //* Deck Unit Behavior

    public void SelectFromDeck()
    {
        cardDisplay.GreyOutCard();
    }

    public void ReturnToDeck()
    {
        cardDisplay.UnGreyOutCard();
    }

    public void MovePositionBy(Vector3 from, Vector3 to, float newScale, float moveTime)
    {
        cardDisplay.MoveTransform(from, to, newScale, moveTime);
    }

    public void MoveTo(Vector3 newPos)
    {
        cardDisplay.MoveToPosition(newPos);
    }

    //---------------------------------
    //* Hand Unit Behavior

    public void UpdateTurn()
    {
        if (card != null && currentTurn > 0)
        {
            currentTurn--;
            cardDisplay.UpdateTurnVisual(currentTurn);
        }
    }


    //---------------------------------
    //* Button Behavior

    public void OnClickOnDeck()
    {
        // Todo Improve efficency/logic if we have time

        CardSelection cardSelection = FindObjectOfType<CardSelection>();
        cardSelection.TryAddCardToHand(this);
    }

    public void OnClickOnHandSelection()
    {
        // Todo Improve efficency/logic if we have time

        CardSelection cardSelection = FindObjectOfType<CardSelection>();
        cardSelection.RemoveCardFromHand(this);
    }

    public void OnClickHandGame()
    {
        if (card == null || currentTurn > 0)
            return;
        
        combatSystem.ClickedOnCardHand(this);
    }

    //---------------------------------
    //* Combat Unit Behavior

    public void PlayCardThisTurn()
    {
        if (card == null)
            return;

        currentTurn = card.turnNo + 1;
        UpdateTurn();
    }

    //---------------------------------
    //* Method Helpers

    public bool CompareCards(CardUnit newUnit)
    {
        return card == newUnit.card;
    }

    public bool IsEmpty()
    {
        return card == null;
    }

    public int GetCurrentTurnCountdown()
    {
        return currentTurn;
    }
}