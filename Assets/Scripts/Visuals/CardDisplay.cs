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
    public Image suitImage;
    public Image greyedOutImage;

    public TMP_Text attackText;
    public TMP_Text defenseText;
    public TMP_Text turnNoText;

    public int attackValue;
    public int defenseValue;
    public string suit;

    public GameObject RemoveFromHandButtonObject;
    public GameObject turnPanelObject;

    private Sprite defaultArtworkImage;
    private Sprite defaultSuitImage;

    private RectTransform rectTransform;

    void Awake()
    {
        defaultArtworkImage = artworkImage.sprite;
        defaultSuitImage = suitImage.sprite;
        rectTransform = GetComponent<RectTransform>();
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
        this.card = card;
    }

    public void RemoveCard()
    {
        nameText.text = "";

        artworkImage.sprite = defaultArtworkImage;
        suitImage.sprite = defaultSuitImage;

        attackText.text = "";
        defenseText.text = "";
        if (turnNoText != null)
        {
            turnNoText.text = "";
        }
        this.card = null;
    }

    public void GreyOutCard()
    {
        greyedOutImage.enabled = true;
    }

    public void UnGreyOutCard()
    {
        greyedOutImage.enabled = false;
    }

    public void ShowRemoveButton()
    {
        RemoveFromHandButtonObject.SetActive(true);
    }

    public void HideRemoveButton()
    {
        RemoveFromHandButtonObject.SetActive(false);
    }

    public void UpdateTurnVisual(int newTurn)
    {
        if (newTurn == 0)
        {
            turnPanelObject.SetActive(false);
            return;
        }

        turnPanelObject.SetActive(true);
        turnNoText.text = newTurn.ToString();
    }

    public void MoveTransform(Vector3 from, Vector3 to, float newScale, float moveTime)
    {
        rectTransform.position = from;
        rectTransform.position = to;
        rectTransform.localScale = Vector3.one * newScale;
    }

    public void MoveToPosition(Vector3 pos)
    {
        rectTransform.localPosition = pos;
    }
}