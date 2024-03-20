using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamRotate : MonoBehaviour
{
    [SerializeField] GameObject target;

    [Header("Speed")]
    [SerializeField] float moveSpeed = 300f;
    [SerializeField] float zoomSpeed = 100f;

    [Header("Zoom")]
    [SerializeField] float minDistance = 2f;
    [SerializeField] float maxDistance = 5f;

    void Update()
    {
        CameraControl();
    }

    void CameraControl()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Orbit Rotate �al���yor");
            /* mouse inputu ile kameray� d�nd�r */
            transform.RotateAround(target.transform.position, Vector3.up, ((Input.GetAxisRaw("Mouse X") * Time.deltaTime) * moveSpeed));
            transform.RotateAround(target.transform.position, transform.right, -((Input.GetAxisRaw("Mouse Y") * Time.deltaTime) * moveSpeed));
        }

        /* Zoom i�lemi */
        ZoomCamera();
    }

    void ZoomCamera()
    {
        /* minimum uzakl��� kontrol edip ona g�re zoom i�lemi yap e�er yeterince yak�nsa return et */
        if (Vector3.Distance(transform.position, target.transform.position) <= minDistance && Input.GetAxis("Mouse ScrollWheel") > 0f) { return; }
        if (Vector3.Distance(transform.position, target.transform.position) >= maxDistance && Input.GetAxis("Mouse ScrollWheel") < 0f) { return; }

        /* ileri geri olacak �ekilde sadece z eksenini hareket ettir */
        transform.Translate(
            0f,
            0f,
            (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * zoomSpeed,
            Space.Self
        );
    }
}
