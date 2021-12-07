using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    private Card previousCard;

    public TMP_Text nameText;

    public Image artworkImage;

    public TMP_Text attackText;
    public TMP_Text defenseText;
    public TMP_Text turnNoText;

    public int attackValue;
    public int defenseValue;
    public string suit;

    // Start is called before the first frame update
    void Start()
    {
        if (card != null)
        {
            CopyCard(card);
        }

    }

    public void CopyCard(Card card)
    {
        nameText.text = card.name;

        artworkImage.sprite = card.artwork;

        attackText.text = card.attack.ToString();
        defenseText.text = card.defense.ToString();
        if (turnNoText != null)
        {
            turnNoText.text = card.turnNo.ToString();
        }
        this.card = card;
    }

    public void CopyCardAttack()
    {
        if (card.name == "The Magician" && previousCard != null)
        {
            card = previousCard;
        }
        else
        {
            previousCard = card;
        }
        attackValue = card.attack;
        
    }
    public void CopyCardDefense()
    {
        if (card.name == "The Magician" && previousCard != null)
        {
            card = previousCard;
        }
        else
        {
            previousCard = card;
        }
        if (card.name == "The Lovers" && previousCard != card)
        {
            defenseValue = card.defense * 2;
        }
        else
        {
            defenseValue = card.defense;
        }
    }
    public void CopyCardSuit()
    {
        suit = card.suit;
    }


}
