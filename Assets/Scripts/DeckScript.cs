using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScript
{
    //public List<Card> PlayerDeck = new List<Card>();


    public DeckScript(DeckListObject deckToCreate)
    {
        deck = new List<Card>();
        foreach(Card card in deckToCreate.getDeck())
        {
            deck.Add(card);
        }
    }
    [SerializeField]
    private List<Card> deck;

    /*public Card SetupCards()
    {

    }*/
}
