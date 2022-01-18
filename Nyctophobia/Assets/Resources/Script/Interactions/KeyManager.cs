using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyManager : MonoBehaviour, Iinteract
{
    public static KeyManager Instance;
    public TMP_Text Objective;
    public TMP_Text KeyProgression;
    public AudioSource doorSound;
    [SerializeField] private AudioClip currentDoorSound;

    public bool[] Keys;
    public bool DoorOpen;
    public bool GoNext;
    public int KeyCounter;

    private void Awake()
    {
        Instance = this;
        Keys = new bool[3];
        KeyCounter = 0;
        Objective.text = "Find a way out of here";
    }

    private void Update()
    {
        if (Keys[0] && Keys[1] && Keys[2])
        {
            Objective.text = "Escape through the door";
            DoorOpen = true;
        }

        KeyProgression.text = "Keys " + KeyCounter + " out of 3";
        doorSound.clip = currentDoorSound;
    }

    public void Interact()
    {
        if (!DoorOpen)
        {
            Objective.text = "Find all 3 keys to escape";
        }
        else if (DoorOpen)
        {
            doorSound.Play();
            gameObject.GetComponent<Animator>().SetBool("Keys Collected", true);
        }
    }

    private void AfterAnim()
    {
        GoNext = true;
    }
}