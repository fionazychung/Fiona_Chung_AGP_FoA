using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandSelectionSystem : MonoBehaviour
{
    private DraggableCard draggableCard;
    public CardSelection cardSelection;
    public CardDisplay pickedCardDisplay;
    public Card selectedCard;
    public HandCardDisplay handCardOne;
    public HandCardDisplay handCardTwo;
    public HandCardDisplay handCardThree;
    public HandCardDisplay handCardFour;

    [SerializeField]
    //private DeckListObject deckList;
    private DeckScript deck;
    private HandScript hand;

    // Start is called before the first frame update
    void Start()
    {
        //deck = new DeckScript(deckList);
        hand = new HandScript();
    }

    // Update is called once per frame
    void Update()
    {
        pickedCardDisplay = cardSelection.selectedCard;
        if (pickedCardDisplay != null)
        {

        }
    }

    public void ConfirmHand()
    {

    }
}
