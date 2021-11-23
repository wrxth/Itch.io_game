using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour, Iinteract
{
    public bool insideCloset;

    public void Interact()
    {
        if (!insideCloset) // If the player is not inside the closet it will transport them inside the closet and set the bool to true
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = gameObject.transform.position;
            insideCloset = true;
        }

        else if (insideCloset) // If the player in inside the closet it will transport them outside the closet and set the bool to false
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("Exit Position").transform.position;
            insideCloset = false;
        }
    }
}
