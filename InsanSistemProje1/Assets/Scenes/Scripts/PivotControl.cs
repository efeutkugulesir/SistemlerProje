using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotControl : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pivot kafa olarak deðiþti.");
    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log("Pivot hala kafa deðiþiklik yok.");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Artýk pivot kafa deðil.");
    }

}
