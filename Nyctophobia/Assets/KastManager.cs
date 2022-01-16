using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KastManager : MonoBehaviour
{
    public static KastManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public bool InKast;
}
