using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerHandZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private PlayerCardUsageSystem playerCardSystem;

    // Start is called before the first frame update
    void Start()
    {
        playerCardSystem = GetComponent<PlayerCardUsageSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        playerCardSystem.cardHasLeftPlayerHandZone = false;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            playerCardSystem.cardHasLeftPlayerHandZone = true;
        }
    }
}
