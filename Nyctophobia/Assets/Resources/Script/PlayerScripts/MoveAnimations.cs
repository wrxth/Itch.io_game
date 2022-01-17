using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimations : MonoBehaviour
{
    public static MoveAnimations Instance;
    public Animator charAnim;

    void Start()
    {
        Instance = this;
        charAnim = gameObject.GetComponent<Animator>();
    }
}
