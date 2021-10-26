using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public TMP_Text nameText;

    public Image artworkImage;

    public TMP_Text attackText;
    public TMP_Text defenseText;
    public TMP_Text turnNoText;
    //public TMP_Text turnCountdownText;
    //public TMP_Text healthText;

    public int playerAttackValue;
    public int playerDefenseValue;
    public int enemyAttackValue;
    public int enemyDefenseValue;

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
        if (card != null)
        {
            playerAttackValue = card.attack;
        }
        //print(playerAttackValue);
    }
    public void CopyCardDefense()
    {
        playerDefenseValue = card.defense;
    }

    public void CopyEnemyAttack()
    {
        enemyAttackValue = card.attack;
    }
    public void CopyEnemyDefense()
    {
        enemyDefenseValue = card.defense;
        //print(enemyDefenseValue);
    }


}
