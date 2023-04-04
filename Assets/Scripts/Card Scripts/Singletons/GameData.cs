using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    [Header("Card Setup")]
    public List<Card> everyCards;
    public List<Card> deck;
    public List<Card> hand = new List<Card>(4);

    [Header("Card Combat Tracker")]
    public Card currentPlayerCard;
    public Card currentEnemyCard;
    public Card lastPlayedCard;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Hand Behaviors
    //--------------------
    public void AddCardToHand(Card newCard)
    {
        for (int i = 0; i < hand.Count; i++)
        {
            if (hand[i] == null)
            {
                hand[i] = newCard;
                return;
            }
        }
    }

    public void RemoveCardFromHand(Card card)
    {
        for (int i = 0; i < hand.Count; i++)
        {
            if (hand[i] == card)
            {
                hand[i] = null;
                return;
            }
        }
    }

    public void ResetHand()
    {
        for (int i = 0; i < hand.Count; i++)
        {
            hand[i] = null;
        }
    }

    // Deck Behaviors
    //--------------------
    public void AddCardToDeck(Card wonCard)
    {
        if (!deck.Contains(wonCard))
        {
            deck.Add(wonCard);
        }
    }
}