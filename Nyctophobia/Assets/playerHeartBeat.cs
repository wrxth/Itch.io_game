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
        if (Vector3.Distance(transform.position, Enemy.transform.position) < 5)
        {
            CurrentHeartSounds = HeartSounds[0];
        }
        else if (Vector3.Distance(transform.position, Enemy.transform.position) < 10)
        {
            CurrentHeartSounds = HeartSounds[1];

        }
        else if (Vector3.Distance(transform.position, Enemy.transform.position) < 15)
        {
            CurrentHeartSounds = HeartSounds[2];
            HeartOrigin.Play();
        }
        else
        {
            HeartOrigin.Stop();
        }
    }
}
