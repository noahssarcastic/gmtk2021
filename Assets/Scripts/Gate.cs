using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private bool open = false;

    void Update() {
        if (open) {
            Open();
        } else {
            Close();
        }
    }

    private void Open() {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = Color.grey;
    }

    private void Close() {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void SetOpen(bool value) {
        open = value;
    }
}
