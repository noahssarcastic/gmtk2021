using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourageBooster : MonoBehaviour
{
    [SerializeField] private float courageModifier = 2;
    [SerializeField] private bool isActive = true;

    void Start() {
        gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
    }

    void Update() {
        if (isActive && !gameObject.GetComponent<Collider2D>().enabled) {
            gameObject.GetComponent<Collider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
        } else if (!isActive && gameObject.GetComponent<Collider2D>().enabled) {
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player") {
            collider.gameObject.GetComponent<Status>().SetCourageModifier(courageModifier);
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player") {
            collider.gameObject.GetComponent<Status>().ResetCourageModifier();
        }
    }

    public void SetIsActive(bool value) {
        isActive = value;
    }
}
