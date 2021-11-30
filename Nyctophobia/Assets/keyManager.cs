using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyManager : MonoBehaviour
{
    public static keyManager Instance;

    public bool[] Keys;

    public bool DoorOpen;

    private void Awake()
    {
        Instance = this;
        Keys = new bool[2];
    }

    // Update is called once per frame
    void Update()
    {
        if (Keys[0] && Keys[1] && Keys[2])
        {
            DoorOpen = true;
        }

        if (DoorOpen == true)
        {
            Debug.Log("win");
        }
    }
}
