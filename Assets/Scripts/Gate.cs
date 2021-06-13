using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private bool open = false;
    [SerializeField] private AudioClip openAudioClip;
    [SerializeField] private AudioClip closeAudioClip;

    void Update() {
        if (open && GetComponent<Collider2D>().enabled) {
            Open();
        } else if (!open && !GetComponent<Collider2D>().enabled){
            Close();
        }
    }

    private void Open() {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = Color.grey;
        GetComponent<AudioSource>().PlayOneShot(openAudioClip, 1);
    }

    private void Close() {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<AudioSource>().PlayOneShot(closeAudioClip, 1);
    }

    public void SetOpen(bool value) {
        open = value;
    }
}
