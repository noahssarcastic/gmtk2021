using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPan : MonoBehaviour
{
    [SerializeField] private RectTransform endPosition;
    [SerializeField] private float time = 10;

    void Update()
    {
        Move(endPosition.position);
    }

    private void Move(Vector3 destination) {
        gameObject.transform.position = Vector3.Lerp(
            GetComponent<RectTransform>().position, 
            destination, 
            time);
        // Snap when close enough to prevent annoying slerp behavior
        if ((destination - GetComponent<RectTransform>().position).magnitude <= 0.05f)
            GetComponent<RectTransform>().position = destination;
    }
}
