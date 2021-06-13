using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonTrigger : MonoBehaviour
{
    [SerializeField] Piston piston;
    private int collisionCounter = 0;
    [SerializeField] private AudioClip pressAudioClip;
    [SerializeField] private AudioClip releaseAudioClip;
    private AudioSource audioSource;
    private bool raising;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (raising && collisionCounter == 0) {
            piston.SetRaising(false);
            raising = false;
            // GetComponent<SpriteRenderer>().color = Color.red;
        } else if (!raising && collisionCounter > 0) {
            piston.SetRaising(true);
            raising = true;
            // GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag != "Ground") {
            collisionCounter += 1;
            audioSource.PlayOneShot(pressAudioClip, 1);
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag != "Ground") {
            collisionCounter -= 1;
            audioSource.PlayOneShot(releaseAudioClip, 1);
        }
    }
}
