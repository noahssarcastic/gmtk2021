using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] Gate gate;
    private int collisionCounter = 0;
    [SerializeField] private AudioClip pressAudioClip;
    [SerializeField] private AudioClip releaseAudioClip;
    private AudioSource audioSource;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    void Start() {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    void Update() {
        if (collisionCounter > 0) {
            gate.SetOpen(true);
            GetComponent<SpriteRenderer>().color = Color.green;
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
            if (collisionCounter == 0) {
                gate.SetOpen(false);
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
