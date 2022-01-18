using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Iinteract
{
    [SerializeField] private int whichKey;

    [SerializeField] private GameObject NewEnemie;

    [SerializeField] public AudioSource keySource;
    [SerializeField] private AudioClip keySound;

    private void Start()
    {
        keySource.clip = keySound;
    }

    public void Interact()
    {
        NewEnemie.SetActive(true);
        KeyManager.Instance.Keys[whichKey] = true;
        keySource.Play();
        KeyManager.Instance.KeyCounter++;
        Destroy(gameObject);
    }
}