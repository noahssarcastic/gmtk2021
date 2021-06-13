using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterTrigger : MonoBehaviour
{
    [SerializeField] CourageBooster booster;
    private int collisionCounter = 0;

    void Start() {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    void Update() {
        if (collisionCounter > 0) {
            booster.SetIsActive(true);
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
            if (collisionCounter == 0) {
                booster.SetIsActive(false);
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
