using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimations : MonoBehaviour
{
    public static MoveAnimations Instance;
    public Animator charAnim;

    void Start()
    {
        // Enables access to this animator in all other classes
        Instance = this;
        charAnim = gameObject.GetComponent<Animator>();
    }
}
