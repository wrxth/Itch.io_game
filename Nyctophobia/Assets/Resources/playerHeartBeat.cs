using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHeartBeat : MonoBehaviour
{
    [SerializeField] private AudioClip[] HeartSounds;
    [SerializeField] private AudioClip CurrentHeartSounds;
    [SerializeField] private AudioSource HeartOrigin;
    [SerializeField] private GameObject Enemy;


    void Update()
    {
        HeartOrigin.clip = CurrentHeartSounds;
        if (Vector3.Distance(transform.position, Enemy.transform.position) < 13)
        {
            CurrentHeartSounds = HeartSounds[0];

            if (HeartOrigin.isPlaying != true)
            {
                HeartOrigin.Play();
            }
        }
        else if (Vector3.Distance(transform.position, Enemy.transform.position) < 20)
        {
            CurrentHeartSounds = HeartSounds[1];
            if (HeartOrigin.isPlaying != true)
            {
                HeartOrigin.Play();
            }
        }
        else
        {
            HeartOrigin.Stop();
        }
    }
}
