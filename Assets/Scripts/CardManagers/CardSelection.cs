using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Manages the Selection screen deck
*/
public class CardSelection : MonoBehaviour
{
    [Header("Cards Reference")]
    [SerializeField] private CardUnit cardPrefab;
    [SerializeField] private List<CardUnit> deckUnitReference = new List<CardUnit>();
    [SerializeField] private List<CardUnit> selectionUnitReference = new List<CardUnit>(4);

    [Header("Movement Parameters")]
    [SerializeField] private RectTransform[] movePositions = new RectTransform[5];
    [SerializeField] private float moveTimer = 0.2f;
    [SerializeField] private float spaceBetweenCards = 1250f;

    private int currentIndexPosition = 0;

    private void Start()
    {
        InitiateDeck();
    }

    private void InitiateDeck()
    {
        // TODO Some kind of visuals with new unlock cards?

        for (int i = 0; i < GameData.instance.deck.Count; i++)
        {
            deckUnitReference[i].LoadNewCard(GameData.instance.deck[i]);
        }

        // Clear hand from last game
        GameData.instance.ResetHand();

        // Set Deck Position
        SetDeckPositionOnStart();
    }

    //---------------------------------
    //* Deck Unit Behavior

    public void TryAddCardToHand(CardUnit deckUnit)
    {
        if (deckUnit.IsEmpty())
            return;

        for (int i = 0; i < selectionUnitReference.Count; i++)
        {
            if (selectionUnitReference[i].CompareCards(deckUnit))
                return;

            if (selectionUnitReference[i].IsEmpty())
            {
                selectionUnitReference[i].LoadNewCard(deckUnit.card);
                GameData.instance.AddCardToHand(deckUnit.card);
                deckUnit.SelectFromDeck();
                return;
            }
        }
    }

    //---------------------------------
    //* Hand Selection Unit Behavior

    public void RemoveCardFromHand(CardUnit handUnit)
    {
        if (handUnit.IsEmpty())
            return;

        for (int i = 0; i < deckUnitReference.Count; i++)
        {
            if (deckUnitReference[i].CompareCards(handUnit))
            {
                deckUnitReference[i].ReturnToDeck();
                GameData.instance.RemoveCardFromHand(handUnit.card);
                handUnit.UnloadCurrentCard();
                return;
            }
        }
    }

    //---------------------------------
    //* Deck Display Behavior

    public void ScrollHorizontal(bool rightScroll)
    {
        // Check if we can move
        if (rightScroll && currentIndexPosition + 1 == deckUnitReference.Count)
            return;
        if (!rightScroll && currentIndexPosition == 0)
            return;

        int direction = rightScroll ? -1 : 1;

        // Move 3 Cards First
        if (currentIndexPosition != 0)
        {
            deckUnitReference[currentIndexPosition - 1].MovePositionBy(
                movePositions[1].position,
                movePositions[1 + direction].position,
                rightScroll ? 1f : 1.5f,
                moveTimer);
        }
        deckUnitReference[currentIndexPosition].MovePositionBy(
            movePositions[2].position,
            movePositions[2 + direction].position,
            1f,
            moveTimer);
        if (currentIndexPosition != deckUnitReference.Count)
        {
            deckUnitReference[currentIndexPosition + 1].MovePositionBy(
                movePositions[3].position,
                movePositions[3 + direction].position,
                rightScroll ? 1.5f : 1f,
                moveTimer);
        }

        // Set new Index
        if (rightScroll)
            currentIndexPosition = ++currentIndexPosition > 20 ? 0 : currentIndexPosition;
        else
            currentIndexPosition = --currentIndexPosition < 0 ? 20 : currentIndexPosition;

        // Enter 4th Card
        int comingIndex = rightScroll ? 4 : 0;
        deckUnitReference[currentIndexPosition - direction].MovePositionBy(
            movePositions[comingIndex].position,
            movePositions[comingIndex + direction].position,
            1f,
            moveTimer);
    }

    private void SetDeckPositionOnStart()
    {
        // Place every cards in a row
        for (int i = 0; i < deckUnitReference.Count; i++)
        {
            deckUnitReference[i].MoveTo(new Vector3(i * spaceBetweenCards, 0f, 0f));
        }
    }
}