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
        // If all keys are found, changes the objective text and
        // allows the door to be opened and let you win the game
        if (Keys[0] && Keys[1] && Keys[2])
        {
            Objective.text = "Escape through the door";
            DoorOpen = true;
        }

        // Makes sure the progression text show your current keys
        // and that the final door has the right audio to play
        KeyProgression.text = "Keys " + KeyCounter + " out of 3";
        doorSound.clip = currentDoorSound;
    }

    public void Interact()
    {
        // Does interactions with the door based on how many keys you have
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

    // Makes sure you win after the door animation is done playing
    private void AfterAnim()
    {
        GoNext = true;
    }
}
