using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Iinteract
{
    [SerializeField] private int WhichKey;

    public void Interact()
    {
        keyManager.Instance.Keys[WhichKey] = true;
        keyManager.Instance.KeyCounter++;
        Destroy(gameObject);
    }
}
