using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotControl : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pivot kafa olarak de�i�ti.");
    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log("Pivot hala kafa de�i�iklik yok.");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Art�k pivot kafa de�il.");
    }

}
