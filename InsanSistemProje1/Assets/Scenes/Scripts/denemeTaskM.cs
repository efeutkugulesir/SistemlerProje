using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class denemeTaskM : MonoBehaviour
{
    public GameObject objectToFind;
    string tagName = "SomeTag";
    public AudioSource audioSource;
    //public SomeScript someScript;
    //public Rigidbody rigidbody;
    public BoxCollider boxCollider;

    
    void Start()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out hit, 100.0f))
        //    {
        //        if (hit.collider.gameObject == gameObject)
        //        {
        //            if (hit.collider.tag == "Deselected")
        //                hit.collider.tag = "Selected";
        //            else if (hit.collider.tag == "Selected")
        //                hit.collider.tag = "Deselected";
        //        }
        //    }
        //}
        objectToFind = GameObject.FindGameObjectWithTag(tagName);
        audioSource = objectToFind.GetComponent<AudioSource>();
        //someScript = objectToFind.GetComponent<SomeScript>();
        //rigidbody = objectToFind.GetComponent<Rigidbody>();
        boxCollider = objectToFind.GetComponent<BoxCollider>();
        //Vücut parçalarý tagler SomeTag
    }
}
