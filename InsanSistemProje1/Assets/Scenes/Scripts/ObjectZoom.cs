using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectZoom : MonoBehaviour
{
    public Camera mainCam;

    private float doubleClickStart = 0;

    private float doubleClickLapseTime = 0.3f;


    void Update()
    {
        CheckDoubleClick();
    }

    void CheckDoubleClick()
    {

        if (Input.GetMouseButtonUp(0))
        {

            if ((Time.time - doubleClickStart) < doubleClickLapseTime)
            {
                this.OnDoubleClick();
                doubleClickStart = -1;
            }
            else
            {
                doubleClickStart = Time.time;

            }

        }
    }

    void OnDoubleClick()
    {
        Debug.Log("Double Click");
        mainCam.transform.position = new Vector3(-0.13f, 0.87f, -8);

        Camera.main.orthographicSize = 0.4f;

    }
}
