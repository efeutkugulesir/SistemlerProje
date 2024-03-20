using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomWithMouse : MonoBehaviour
{
    [SerializeField]
    private float ScrollSpeed = 50;

    private Camera ZoomCamera;
    
    private void Start()
    {
        ZoomCamera = Camera.main;
    }

    
    void Update()
    {
        if (ZoomCamera.orthographic)
        {
            ZoomCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }
        else
        {
            ZoomCamera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }
    }
}
