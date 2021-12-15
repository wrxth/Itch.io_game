using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] int NumberOfObstacles;
    
    private List<Transform> ObstaclesWalls;
    void Start()
    {
        ObstaclesWalls = new List<Transform>();
        GameObject temp = GameObject.Find("Obstacles Walls");
        
        for (int i = 0; i < temp.transform.childCount; i++)
        {
            ObstaclesWalls.Add(temp.transform.GetChild(i));
        }

        for (int i = 0; i < NumberOfObstacles; i++)
        {
            int RandomIndex = Random.Range(0, ObstaclesWalls.Count);
            
            Transform RandomWall = ObstaclesWalls[RandomIndex];
            RandomWall.gameObject.SetActive(false);
            ObstaclesWalls.RemoveAt(RandomIndex);
        }

    }

}
