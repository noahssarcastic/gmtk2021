using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] private int levelToLoad;

    void OnTriggerEnter2D(Collider2D other){
        SceneManager.LoadScene(levelToLoad);
    }
}
