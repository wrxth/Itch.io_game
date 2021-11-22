using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyState : MonoBehaviour
{
    public bool hunting;
    public bool dead; 

    public float VisionTime;
    [Tooltip("The time before the enemy stops chasing")]
    public float VisionTimeMax;

    [SerializeField] private EnemyControl EC;
    public IEnumerator EnemieCounter()
    {
        while (VisionTime > 0)
        {
            VisionTime--;
            yield return new WaitForSeconds(1);
        }
        if(VisionTime <= 0)
        {
            hunting = false;
            EC.Check1();
        }
    }
}
