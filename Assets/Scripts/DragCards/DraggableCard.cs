﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 returnPosition;
    private CanvasGroup cvGroup;
    public PlayerCardUsageSystem playerCardSystem;
    CardSelection cardSelection;

    public Card PlayedCard;
    public Card PickedCard;

    // Start is called before the first frame update
    void Start()
    {
        cvGroup = GetComponent<CanvasGroup>();
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
        FindObjectOfType<AudioManager>().GetRandomPickCardSound();
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
                HandCardDisplay handCard = eventData.pointerCurrentRaycast.gameObject.GetComponent<HandCardDisplay>();
                //Debug.Log($"{playerCardSystem}");
                playerCardSystem.CopyCard(cardSelection.selectedCard.card, handCard);
                cardSelection.PickCard();

                if (cardSelection.cardHasLeftDeckZone)
                {
                    PickedCard = cardSelection.selectedCard.card;
                }
            }
            //FindObjectOfType<AudioManager>().PlaySounds("SFX_PlaceCard_1");
            FindObjectOfType<AudioManager>().GetRandomPlaceCardSound();

            cvGroup.blocksRaycasts = true;
            transform.position = returnPosition;
        }

    }
}
