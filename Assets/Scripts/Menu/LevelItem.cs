using System.Collections.Generic;
using UnityEngine;

public class LevelItem : MonoBehaviour
{
    [Header("Level Cards")]
    [SerializeField] private List<Card> levelCards = new List<Card>();

    public void ClickOnLevel()
    {
        Card newEnemy = GetRandomCard(levelCards);
        GameData.instance.currentEnemyCard = newEnemy;

        LoadHandSelectionLevel();
    }

    private void LoadHandSelectionLevel()
    {
        FindObjectOfType<MainMenuController>().HandSelect();
    }

    private Card GetRandomCard(List<Card> cardList)
    {
        bool isOver = false;
        List<Card> activeCards = new List<Card>();

        foreach (Card c in levelCards)
        {
            activeCards.Add(c);
        }

        while(!isOver)
        {
            Card randomPickedCard = activeCards[Random.Range(0, activeCards.Count)];

            if (!GameData.instance.deck.Contains(randomPickedCard))
            {
                isOver = true;
                return randomPickedCard;
            }

            activeCards.Remove(randomPickedCard);

            if (activeCards.Count == 0)
            {
                return levelCards[Random.Range(0, levelCards.Count)];
            }
        }

        return null;
    }
}