using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCon : MonoBehaviour
{
    public int winScene;

    private KeyManager man;

    private GameObject door;

    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door");
        man = door.GetComponent<KeyManager>();
    }

    void Update()
    {
        // Checks if all win conditions are met
        if (man.DoorOpen && man.GoNext)
        {
            SceneManager.LoadScene(winScene);
        }
    }
}
