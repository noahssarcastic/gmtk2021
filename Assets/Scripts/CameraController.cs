using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerOne;
    [SerializeField] private Transform playerTwo;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);
    [SerializeField] private float baseZoom = 0.7f;
    [SerializeField] private float minZoom = 5f;
    [SerializeField] private float followTimeDelta = 0.8f;

    private Camera cam;

    void Awake() {
        cam = GetComponent<Camera>();
    }

    void Update () 
    {
        Vector3 midpoint = (playerOne.position + playerTwo.position) / 2f; 
        Vector3 cameraDestination = new Vector3 (
            midpoint.x + offset.x, 
            midpoint.y + offset.y, 
            offset.z);
        
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);
        // Snap when close enough to prevent annoying slerp behavior
        if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
            cam.transform.position = cameraDestination;

        float distance = (playerOne.position - playerTwo.position).magnitude;
        float zoom = distance * baseZoom;
        cam.orthographicSize = zoom >= minZoom ? zoom : minZoom;
    }
}
