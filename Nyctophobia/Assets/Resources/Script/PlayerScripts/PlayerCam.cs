using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    private Transform playerPos;
    private Vector3 cameraOffset;

    [SerializeField]private int CameraZoomMin, CameraCurrentZoomIndex, CameraZoomMax;

    private void Start()
    {
        cameraOffset = transform.position;
    }
    void Update()
    {
        playerPos = GameObject.Find("player").transform;
        transform.position = playerPos.transform.position + cameraOffset;

        if(CameraCurrentZoomIndex > CameraZoomMin && Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            Camera.main.fieldOfView--;
            CameraCurrentZoomIndex--;
            
        }
        else if (CameraCurrentZoomIndex < CameraZoomMax && Input.GetAxis("Mouse ScrollWheel") < 0f) // backward
        {
            Camera.main.fieldOfView++;
            CameraCurrentZoomIndex++;
        }
    }
}
