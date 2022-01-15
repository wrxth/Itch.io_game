using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Iinteract
{
    [SerializeField] private int whichKey;

    [SerializeField] private GameObject NewEnemie;
    
    public void Interact()
    {
        NewEnemie.SetActive(true);
        KeyManager.Instance.Keys[whichKey] = true;

        KeyManager.Instance.KeyCounter++;
        Destroy(gameObject);
    }
}