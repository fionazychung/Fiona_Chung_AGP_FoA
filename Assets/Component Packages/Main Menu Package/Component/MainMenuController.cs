using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject inGameHelpPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("PLAYGAME");
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("QUITGAME");
    }
    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void StageSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void HandSelect()
    {
        SceneManager.LoadScene(2);
    }

    //for the level selection buttons

    public void Empress()
    {
        SceneManager.LoadScene(3);
    }

    //Tutorial/help buttons
    public void InGameHelp()
    {
        inGameHelpPanel.SetActive(true);
    }
    public void InGameHelpClose()
    {
        inGameHelpPanel.SetActive(false);
    }
}
