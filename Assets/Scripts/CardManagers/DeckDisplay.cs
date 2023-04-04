using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckDisplay : MonoBehaviour
{
    [Header("Deck Viewer Unit Reference")]
    [SerializeField] private List<CardUnit> deckViewerUnit = new List<CardUnit>();

    void Start()
    {
        for (int i = 0; i < GameData.instance.deck.Count; i++)
        {
            deckViewerUnit[i].LoadNewCard(GameData.instance.deck[i]);
        }
    }
}