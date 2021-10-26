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

    public Card PlayedCard;

    // Start is called before the first frame update
    void Start()
    {
        cvGroup = GetComponent<CanvasGroup>();
        playerCardSystem = transform.parent.GetComponent<PlayerCardUsageSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("On begin drag");
        if (cvGroup.interactable)
        {
            playerCardSystem.selectedCard = GetComponent<HandCardDisplay>();
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
            playerCardSystem.PlayCard();
            if (playerCardSystem.cardHasLeftPlayerHandZone)
            {
                PlayedCard = playerCardSystem.selectedCard.card;
            }

            cvGroup.blocksRaycasts = true;
            transform.position = returnPosition;
        }

    }
}
