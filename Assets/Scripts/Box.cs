using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private bool isMoving = false;
    // Update is called once per frame
    void Update()
    {
        if (!isMoving && Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > 0) {
            GetComponent<AudioSource>().Play();
            isMoving = true;
        } else if (isMoving && Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) == 0) {
            GetComponent<AudioSource>().Stop();
            isMoving = false;
        }
    }
}
