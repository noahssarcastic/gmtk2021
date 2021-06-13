using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    [SerializeField] private bool raising = false;

    void Update() {
        if (raising) {
            Raise();
        } else {
            Lower();
        }
    }

    private void Raise() {
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    private void Lower() {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void SetRaising(bool value) {
        raising = value;
    }
}
