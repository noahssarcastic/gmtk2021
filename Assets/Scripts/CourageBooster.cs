using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CourageBooster : MonoBehaviour
{
    [SerializeField] private float courageModifier = 2;
    [SerializeField] private bool isActive = true;
    private AudioSource audioSource;
    [SerializeField] private AudioClip enterAudioClip;
    [SerializeField] private AudioClip exitAudioClip;

    void Start() {
        // GetComponent<SpriteRenderer>().color = Color.magenta;
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (isActive && !gameObject.GetComponent<Collider2D>().enabled) {
            gameObject.GetComponent<Collider2D>().enabled = true;
            GetComponent<Light2D>().enabled = true;
            // gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
        } else if (!isActive && gameObject.GetComponent<Collider2D>().enabled) {
            gameObject.GetComponent<Collider2D>().enabled = false;
            // gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
            GetComponent<Light2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player") {
            collider.gameObject.GetComponent<Status>().SetCourageModifier(courageModifier);
            audioSource.PlayOneShot(enterAudioClip, 1);
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player") {
            collider.gameObject.GetComponent<Status>().ResetCourageModifier();
            audioSource.PlayOneShot(exitAudioClip, 1);
        }
    }

    public void SetIsActive(bool value) {
        isActive = value;
    }
}
