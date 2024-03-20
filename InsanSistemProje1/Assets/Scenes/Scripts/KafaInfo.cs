using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KafaInfo : MonoBehaviour
{
    //public bool canTake = false;
    public string clickMsg = "BEYÝN  Yaklaþýk 100 milyar nöron ve çok daha fazla destek hücrelerinden oluþur.";
    //public string takeMsg = "You can't take that.";
    //public string openMsg = "You can't do that.";
    public GameObject messageObject;
    string message;
    GameObject MessageDeneme;
    private bool showLabel = true;
    // InvokeRepeating("ToggleLabel", 1,1); InvokeRepeating("ClearMessage", 1, 3); }
    //public void ToggleLabel()
    //{
    //    showLabel = !showLabel;
    //}
    public void ClearMessage()
    {
        message = "";
    }
    private void Update()
    {
        OnMouseDown();
    }
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            message = clickMsg;
            Debug.Log("Pressed left click.");
        }
        //if (Input.GetMouseButtonDown(1))
        //    message = takeMsg;
        //Debug.Log("Pressed right click.");
        //if (Input.GetMouseButtonDown(2))
        //    message = openMsg;
        //Debug.Log("Pressed middle click.");
    }
    void OnGUI()
    {
        if (showLabel)
        {
            GUI.Label(new Rect(250, 700, 1000, 1000), "<color=white><size=32>" + message + "</size></color>");
        }
    }
}
