using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private LayerMask InterActable;
    [SerializeField] private GameObject interactE;

    void Update()
    {
        // Interacts with objects that are interactible and in range of the overlapsphere
        Collider[] objects = Physics.OverlapSphere(transform.position, 0.75f, InterActable);
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < objects.Length; i++)
            {
                Iinteract ii = objects[i].gameObject.GetComponent<Iinteract>();

                if (ii != null)
                {
                    ii.Interact();
                }
            }
        }
        // If there are any interactibles in range this will show the indicator in-game
        if (objects.Length > 0)
        {
            interactE.SetActive(true);
        }
        else if (objects.Length == 0)
        {
            interactE.SetActive(false);
        }
    }
}
