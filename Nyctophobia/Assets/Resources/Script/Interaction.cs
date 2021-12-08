using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private LayerMask InterActable;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] objects = Physics.OverlapSphere(transform.position, 1f, InterActable);

            for (int i = 0; i < objects.Length; i++)
            {
                Iinteract ii = objects[i].gameObject.GetComponent<Iinteract>();

                if (ii != null)
                {
                    ii.Interact();
                }
            }
        }
    }
}
