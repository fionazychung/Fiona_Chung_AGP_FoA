using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 returnPosition;
    private CanvasGroup cvGroup;
    PlayerCardUsageSystem playerCardSystem;
    CardSelection cardSelection;

    public Card PlayedCard;
    public Card PickedCard;

    // Start is called before the first frame update
    void Start()
    {
        cvGroup = GetComponent<CanvasGroup>();
        playerCardSystem = transform.parent.GetComponent<PlayerCardUsageSystem>();
        cardSelection = transform.parent.GetComponent<CardSelection>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("On begin drag");
        if (cvGroup.interactable)
        {
            if (playerCardSystem != null)
            {
                playerCardSystem.selectedCard = GetComponent<HandCardDisplay>();
            }
            if (cardSelection != null)
            {
                cardSelection.selectedCard = GetComponent<CardDisplay>();
            }
            returnPosition = transform.position;
            cvGroup.blocksRaycasts = false;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (cvGroup.interactable)
        {
            transform.position = new Vector3(transform.position.x, eventData.position.y, transform.position.z);
        }

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (cvGroup.interactable)
        {
            if (playerCardSystem != null)
            {
                playerCardSystem.PlayCard();
                if (playerCardSystem.cardHasLeftPlayerHandZone)
                {
                    PlayedCard = playerCardSystem.selectedCard.card;
                }
            }
            if (cardSelection != null)
            {
                Debug.Log($"{eventData.pointerCurrentRaycast.gameObject}");
                cardSelection.PickCard();
                if (cardSelection.cardHasLeftDeckZone)
                {
                    PickedCard = cardSelection.selectedCard.card;
                }
            }

            cvGroup.blocksRaycasts = true;
            transform.position = returnPosition;
        }

    }
}
