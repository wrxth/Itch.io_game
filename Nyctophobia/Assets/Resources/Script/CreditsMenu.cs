using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour
{
    // Makes you go back to the main menu
    public void BackFromEndCredits()
    {
        SceneManager.LoadScene(0);
    }
}
