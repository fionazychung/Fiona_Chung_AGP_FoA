using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject inGameHelpPanel;
    public GameObject deckInventory;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Debug.Log("PLAYGAME");
        FindObjectOfType<AudioManager>().GetRandomButtonClickSound();
    }
    public void ExitGame()
    {
        Application.Quit();
        //Debug.Log("QUITGAME");
        FindObjectOfType<AudioManager>().GetRandomButtonClickSound();
    }
    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().GetRandomButtonClickSound();
    }

    public void StageSelect()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<AudioManager>().GetRandomButtonClickSound();
    }

    public void HandSelect()
    {
        SceneManager.LoadScene(2);
        FindObjectOfType<AudioManager>().GetRandomButtonClickSound();
    }

    //for the level selection buttons

    public void Empress()
    {
        SceneManager.LoadScene(3);
        FindObjectOfType<AudioManager>().GetRandomButtonClickSound();
    }

    //Tutorial/help buttons
    public void InGameHelp()
    {
        inGameHelpPanel.SetActive(true);
        FindObjectOfType<AudioManager>().GetRandomButtonClickSound();
    }
    public void InGameHelpClose()
    {
        inGameHelpPanel.SetActive(false);
        FindObjectOfType<AudioManager>().GetRandomButtonClickSound();
    }

    //View Deck
    public void ViewDeck()
    {
        deckInventory.SetActive(true);
        FindObjectOfType<AudioManager>().GetRandomButtonClickSound();
    }
    public void CloseDeckView()
    {
        deckInventory.SetActive(false);
        FindObjectOfType<AudioManager>().GetRandomButtonClickSound();
    }

    public void ClickSFX()
    {
        FindObjectOfType<AudioManager>().GetRandomButtonClickSound();
    }
}
