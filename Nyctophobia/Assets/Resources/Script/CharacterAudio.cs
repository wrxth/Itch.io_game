using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    public static CharacterAudio Instance;
    [SerializeField] private AudioClip[] MoveSounds;
    [SerializeField] private AudioClip CurrentMoveSounds;
    [SerializeField] public AudioSource MoveOrigin;
    public bool Moving;
    public bool Running;

    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        // Makes sure the right audio plays when
        // the player is walking or running
        MoveOrigin.clip = CurrentMoveSounds;
        if (Moving)
        {
            CurrentMoveSounds = MoveSounds[0];
            if (!MoveOrigin.isPlaying)
            {
                MoveOrigin.Play();
            }
        }
        else if (Running)
        {
            CurrentMoveSounds = MoveSounds[1];
            if (!MoveOrigin.isPlaying)
            {
                MoveOrigin.Play();
            }
        }
        else {MoveOrigin.Stop();}
    }
}
