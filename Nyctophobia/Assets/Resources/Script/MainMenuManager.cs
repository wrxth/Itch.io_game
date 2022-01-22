using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject canMain;
    [SerializeField] GameObject canCred;
    [SerializeField] GameObject canCont;

    // This script enables UI elements and disables them upon the press of buttons on the main menu of the game.
    // Another loads the game and the last one shuts down the game window.
    private void Start()
    {
        canMain.SetActive(true);
        canCred.SetActive(false);
        canCont.SetActive(false);
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void settingsOpen()
    {
        //empty
    }
    public void creditsOpen()
    {
        canMain.SetActive(false);
        canCred.SetActive(true);
        canCont.SetActive(false);
    }
    public void backToMenu()
    {
        canMain.SetActive(true);
        canCred.SetActive(false);
        canCont.SetActive(false);
    }
    public void controlsOpen()
    {
        canMain.SetActive(false);
        canCred.SetActive(false);
        canCont.SetActive(true);
    }
}
