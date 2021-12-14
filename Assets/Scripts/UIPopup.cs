using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIPopup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject popupImg;

    public bool popupOn = false;
    private bool mouse_over = false;
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
            FindObjectOfType<AudioManager>().Play("SFX_FireHover");
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
        //Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        popupOn = false;
        //Debug.Log("Mouse exit");
    }
}
