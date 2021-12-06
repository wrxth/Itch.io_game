using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCon : MonoBehaviour
{
    public int winScene;

    private keyManager man;

    private GameObject door;

    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door");
        man = door.GetComponent<keyManager>();
    }

    void Update()
    {
        if (man.DoorOpen && man.GoNext)
        {
            SceneManager.LoadScene(winScene);
        }
    }
}
