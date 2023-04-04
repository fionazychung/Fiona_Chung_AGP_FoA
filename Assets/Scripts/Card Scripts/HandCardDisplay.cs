using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandCardDisplay : MonoBehaviour
{
    public Card card;

    public TMP_Text nameText;

    public Image artworkImage;
    public Image suitImage;

    public TMP_Text attackText;
    public TMP_Text defenseText;
    public TMP_Text turnNoText;
    public TMP_Text turnCountdownText;
    //public TMP_Text healthText;

    public int playerAttackValue;
    public int playerDefenseValue;
    public int enemyAttackValue;
    public int enemyDefenseValue;
    public int countdownNo;
    public string playerSuit;

    public GameObject turnCdPanel;

    public CanvasGroup cvGroup;

    //public HandScript handScript;

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
        suitImage.sprite = card.suitIcon;

        attackText.text = card.attack.ToString();
        defenseText.text = card.defense.ToString();
        if (turnNoText != null)
        {
            turnNoText.text = card.turnNo.ToString();
        }
        if (turnCountdownText != null)
        {
            turnCountdownText.text = "";
        }
        this.card = card;
    }

    public void CopyCardAttack()
    {
        if (card != null)
        {
            playerAttackValue = card.attack;
        }
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
    }

    public void CopyTurnNo()
    {
        if (cvGroup != null)
        {
            cvGroup.interactable = false;
            turnCdPanel.SetActive(true);
        }
        countdownNo = card.turnNo;
        if (turnCountdownText != null)
        {
            turnCountdownText.text = countdownNo.ToString();
        }
    }

    public void CopyHandCardSuit()
    {
        playerSuit = card.suit;
    }


    private void Update()
    {
        if (countdownNo == 0)
        {
            turnCdPanel.SetActive(false);
        }
    }
}
