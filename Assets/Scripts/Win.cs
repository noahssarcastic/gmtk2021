using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] private int levelToLoad;

    private int playerCount;

    void Update() {
        if (playerCount >= 2) {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            playerCount += 1;
        }  
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            playerCount -= 1;
        }
    }
}
