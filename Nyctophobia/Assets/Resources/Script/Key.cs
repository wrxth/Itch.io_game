using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Iinteract
{
    [SerializeField] private int whichKey;
    
    public void Interact()
    {
        KeyManager.Instance.Keys[whichKey] = true;

        KeyManager.Instance.KeyCounter++;
        Destroy(gameObject);
    }
}