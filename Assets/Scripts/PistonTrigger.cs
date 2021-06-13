using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonTrigger : MonoBehaviour
{
    [SerializeField] Piston piston;
    private int collisionCounter = 0;

    void Update() {
        if (collisionCounter == 0) {
            piston.SetRaising(false);
            GetComponent<SpriteRenderer>().color = Color.red;
        } else {
            piston.SetRaising(true);
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag != "Ground") {
            collisionCounter += 1;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag != "Ground") {
            collisionCounter -= 1;
        }
    }
}
