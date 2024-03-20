using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRotation : MonoBehaviour
{
    float rotationSpeed = 1f;
    [SerializeField] Transform tf;

    private void OnMouseDrag()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed * 100;
        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed * 100;

        tf.Rotate(Vector3.down, XaxisRotation);
        tf.Rotate(Vector3.right, YaxisRotation);
    }

    //zoom in and out
    float cameraDistanceMax = 20f;
    float cameraDistanceMin = 5f;
    float cameraDistance = 10f;
    float scrollSpeed = 0.5f;

    void Update()
    {
        cameraDistance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);

        // set camera position
    }
}
