using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
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
        SceneManager.LoadScene(2);
    }
    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
}