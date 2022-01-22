using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Iinteract
{
    [SerializeField] private int whichKey;

    [SerializeField] private GameObject NewEnemy;

    [SerializeField] public AudioSource keySource;
    [SerializeField] private AudioClip keySound;

    private void Start()
    {
        keySource.clip = keySound;
    }

    // Enables the assigned enemy, shows that the key
    // has been picked up, plays audio and destroys it
    public void Interact()
    {
        NewEnemy.SetActive(true);
        KeyManager.Instance.Keys[whichKey] = true;
        keySource.Play();
        KeyManager.Instance.KeyCounter++;
        Destroy(gameObject);
    }
}
