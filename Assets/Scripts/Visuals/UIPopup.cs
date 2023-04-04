using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIPopup : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    /* public GameObject popupImg;

    public bool popupOn = false;
    private bool mouse_over = false;

    public CardDisplay cardDisplay;
    public HandCardDisplay handCardDisplay;

    void Update()
    {
        if (mouse_over)
        {
            popupOn = true;

            //Debug.Log("Mouse Over");
        }
        if (popupOn == true)
        {
            popupImg.SetActive(true);
            //Debug.Log("Played");
        }
        else
        {
            popupImg.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        //FindObjectOfType<AudioManager>().Play("SFX_WaterHover");

        if (cardDisplay != null && cardDisplay.card != null)
        {
            // cardDisplay.CopyCardSuit();
            if (cardDisplay.suit == "Water")
            {
                FindObjectOfType<AudioManager>().PlaySounds("SFX_WaterHover");
                FindObjectOfType<AudioManager>().PlaySounds("ATMOS_WaterHover");
            }
            if (cardDisplay.suit == "Earth")
            {
                FindObjectOfType<AudioManager>().PlaySounds("SFX_EarthHover");
                FindObjectOfType<AudioManager>().PlaySounds("ATMOS_EarthHover");
            }
            if (cardDisplay.suit == "Fire")
            {
                FindObjectOfType<AudioManager>().PlaySounds("SFX_FireHover");
                FindObjectOfType<AudioManager>().PlaySounds("ATMOS_FireHover");
            }
            if (cardDisplay.suit == "Air")
            {
                FindObjectOfType<AudioManager>().PlaySounds("SFX_WindHover");
                FindObjectOfType<AudioManager>().PlaySounds("ATMOS_WindHover");
            }
        }


        if (handCardDisplay != null && handCardDisplay.card != null)
        {
            handCardDisplay.CopyHandCardSuit();
            if (handCardDisplay.playerSuit == "Water")
            {
                FindObjectOfType<AudioManager>().PlaySounds("SFX_WaterHover");
                FindObjectOfType<AudioManager>().PlaySounds("ATMOS_WaterHover");
            }
            if (handCardDisplay.playerSuit == "Earth")
            {
                FindObjectOfType<AudioManager>().PlaySounds("SFX_EarthHover");
                FindObjectOfType<AudioManager>().PlaySounds("ATMOS_EarthHover");
            }
            if (handCardDisplay.playerSuit == "Fire")
            {
                FindObjectOfType<AudioManager>().PlaySounds("SFX_FireHover");
                FindObjectOfType<AudioManager>().PlaySounds("ATMOS_FireHover");
            }
            if (handCardDisplay.playerSuit == "Air")
            {
                FindObjectOfType<AudioManager>().PlaySounds("SFX_WindHover");
                FindObjectOfType<AudioManager>().PlaySounds("ATMOS_WindHover");
            }
        }
        //Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        popupOn = false;
        //Debug.Log("Mouse exit");
    } */
}
