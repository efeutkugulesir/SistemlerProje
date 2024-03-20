using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClick : MonoBehaviour
{
    /// Hareket tamamlandýðýnda kameranýn objeye olan uzaklýðý </summary>
    public float DistanceToObject = 4;

    /// Kameranýn hareket hýzý </summary>
    public float MovementSpeed = 0.5F;

    /// Objeye týklandýðýnda hareket edecek olan kamera </summary>
    public Camera CameraToMove;

    private Vector3 NormalVector;
    private Vector3 CameraStartPosition;
    private Vector3 CameraEndPosition;
    private Quaternion CameraStartRotation;
    private Quaternion CameraEndRotation;
    private bool DoMovement = false;

    private float LerpMovement = 0;
    private Collider collider;
    public TaskManager taskManager;
    void Start()
    {
        CameraToMove = Camera.main;
       /* MeshCollider collider = this.gameObject.GetComponent<MeshCollider>();
        if (collider == null)
        {
            //If there is no collider, add one so the raycast works.
            Debug.Log("No collider found. Adding one.");
            this.gameObject.AddComponent<MeshCollider>();
        }*/
    }

    // void Update()
    // {
    //     ClickRaycastUpdate();
    //     MoveToPointUpdate();
    //}

    private void Update()
    {
        ClickRaycastUpdate();
       MoveToPointUpdate();
    }
    private void ClickRaycastUpdate()
    {
        if (Input.GetMouseButtonDown(0) && Camera.main.pixelRect.Contains(Input.mousePosition))
        {
            Ray ray = CameraToMove.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("InfoItem");
                if (hit.transform.gameObject.GetComponent<InfoItem>())
                {
                    taskManager.currentInfoItem = hit.transform.gameObject.GetComponent<InfoItem>();
                    Debug.Log("InfoItem");
                    collider = hit.transform.gameObject.GetComponent<Collider>();
                    NormalVector = GetMeshColliderNormal(hit, hit.transform.gameObject.GetComponent<MeshCollider>());
                   // NormalVector = new Vector3(1, 0, 0);
                    CameraStartPosition = CameraToMove.transform.position;
                    CameraStartRotation = CameraToMove.transform.rotation;
                    CameraEndPosition = new Vector3(hit.point.x + NormalVector.x * DistanceToObject, hit.point.y + NormalVector.y * DistanceToObject, hit.point.z + NormalVector.z * DistanceToObject);
                    CameraEndRotation = Quaternion.LookRotation(hit.point - CameraEndPosition);
                    LerpMovement = 0F;
                    DoMovement = true;
                    Debug.Log("Týklandý");
                    print(" týklandý" + DoMovement + "  " + LerpMovement);
                }
                // if yorum satýrýna alýndýðý anda týklanan her yere odaklanmaya baþlýyor.
                // geri alýndýðýnda ise odaklama yapmýyor
            }
        }
    }

    private void MoveToPointUpdate()
    {
        Debug.Log("DoMovement");
        if (DoMovement)
        {
            Debug.Log("DoMovement work");
            CameraToMove.transform.position = Vector3.Lerp(CameraStartPosition, CameraEndPosition, LerpMovement);
            CameraToMove.transform.rotation = Quaternion.Lerp(CameraStartRotation, CameraEndRotation, LerpMovement);
            LerpMovement += Time.deltaTime * MovementSpeed;
            if (LerpMovement >= 1F)
            {
                LerpMovement = 0F;
                DoMovement = false;
            }
        }
    }
    
    private Vector3 GetMeshColliderNormal(RaycastHit hit,MeshCollider collider)
    {
       // MeshCollider collider = gameObject.GetComponent<MeshCollider>();
        Mesh mesh = collider.sharedMesh;
        Vector3[] normals = mesh.normals;
        int[] triangles = mesh.triangles;

        Vector3 n0 = normals[triangles[hit.triangleIndex * 3 + 0]];
        Vector3 n1 = normals[triangles[hit.triangleIndex * 3 + 1]];
        Vector3 n2 = normals[triangles[hit.triangleIndex * 3 + 2]];

        Vector3 baryCenter = hit.barycentricCoordinate;
        Vector3 interpolatedNormal = n0 * baryCenter.x + n1 * baryCenter.y + n2 * baryCenter.z;
        interpolatedNormal.Normalize();
        interpolatedNormal = hit.transform.TransformDirection(interpolatedNormal);
        return interpolatedNormal;
    }
}
