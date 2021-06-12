using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);
    [SerializeField] private float baseZoom = 0.7f;
    [SerializeField] private float minZoom = 5f;
    [SerializeField] private float followTimeDelta = 0.8f;

    private Camera cam;

    void Awake() {
        cam = GetComponent<Camera>();
    }

    void Update() {
        Vector3 positionOne = playerOne.transform.position;
        Vector3 positionTwo = playerTwo.transform.position;
        float distance = (positionOne - positionTwo).magnitude;

        if (distance > 20f) {
            FocusCamera();
        } else {
            SplitCamera();
        } 
    }

    private void SplitCamera() {
        Vector3 positionOne = playerOne.transform.position;
        Vector3 positionTwo = playerTwo.transform.position;

        Vector3 midpoint = (positionOne + positionTwo) / 2f;
        Vector3 cameraDestination = new Vector3 (
            midpoint.x + offset.x, 
            midpoint.y + offset.y, 
            offset.z);
        MoveCamera(cameraDestination);
        
        float distance = (positionOne - positionTwo).magnitude;
        float zoom = distance * baseZoom;
        ZoomCamera(zoom);
    }

    private void FocusCamera() {
        Vector2 position;
        if (playerOne.GetComponent<Controller>().getIsActive()) {
            position = playerOne.transform.position;
        } else if (playerTwo.GetComponent<Controller>().getIsActive()) {
            position = playerTwo.transform.position;
        } else {
            position = Vector2.zero;
        }

        Vector3 cameraDestination = new Vector3 (
            position.x + offset.x, 
            position.y + offset.y, 
            offset.z);
        MoveCamera(cameraDestination);
    }

    private void MoveCamera(Vector3 destination) {
        cam.transform.position = Vector3.Slerp(
            cam.transform.position, 
            destination, 
            followTimeDelta);
        // Snap when close enough to prevent annoying slerp behavior
        if ((destination - cam.transform.position).magnitude <= 0.05f)
            cam.transform.position = destination;
    }

    private void ZoomCamera(float zoom) {
        cam.orthographicSize = zoom >= minZoom ? zoom : minZoom;
    }
}
