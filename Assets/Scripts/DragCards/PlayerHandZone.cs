using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerHandZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private PlayerCardUsageSystem playerCardSystem;
    private CardSelection cardSelection;

    // Start is called before the first frame update
    void Start()
    {
        if (playerCardSystem != null)
        {
            playerCardSystem = GetComponent<PlayerCardUsageSystem>();
        }
        if (cardSelection != null)
        {
            cardSelection = GetComponent<CardSelection>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (playerCardSystem != null)
        {
            playerCardSystem.cardHasLeftPlayerHandZone = false;
        }
        if (cardSelection != null)
        {
            cardSelection.cardHasLeftDeckZone = false;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (playerCardSystem != null)
            {
                playerCardSystem.cardHasLeftPlayerHandZone = true;
            }
            if (cardSelection != null)
            {
                cardSelection.cardHasLeftDeckZone = true;
            }

        }
    }
}

/*public class PlayerDeckZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

}*/
