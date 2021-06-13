using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    [SerializeField] private bool raising = false;
    [SerializeField] private float height = 10;
    [SerializeField] private float time = 0.01f;
    private Vector3 startPosition;

    [SerializeField] private AudioClip raiseAudioClip;
    [SerializeField] private AudioClip lowerAudioClip;
    private AudioSource audioSource;

    void Awake() {
        startPosition = gameObject.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (raising) {
            Raise();
        } else {
            Lower();
        }
    }

    private void Raise() {
        // GetComponent<SpriteRenderer>().color = Color.green;
        Vector3 destination = startPosition + Vector3.up * height;
        Move(destination);
    }

    private void Lower() {
        // GetComponent<SpriteRenderer>().color = Color.red;
        Move(startPosition);
    }

    public void SetRaising(bool value) {
        raising = value;
        if (value) {
            audioSource.PlayOneShot(raiseAudioClip, 1);
        } else {
            audioSource.PlayOneShot(lowerAudioClip, 1);
        }
    }

    private void Move(Vector3 destination) {
        gameObject.transform.position = Vector3.Lerp(
            gameObject.transform.position, 
            destination, 
            time);
        // Snap when close enough to prevent annoying slerp behavior
        if ((destination - gameObject.transform.position).magnitude <= 0.05f)
            gameObject.transform.position = destination;
    }
}
