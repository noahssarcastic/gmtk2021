using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courage : MonoBehaviour
{
    [SerializeField] private GameObject characterOne;
    [SerializeField] private GameObject characterTwo;
    private Controller controllerOne;
    private Controller controllerTwo;

    [SerializeField] private CourageBar courageBar;

    private const float baseCourage = 100;

    void Awake() {
        controllerOne = characterOne.GetComponent<Controller>();
        controllerTwo = characterTwo.GetComponent<Controller>();
    }

    void Update() {
        Vector3 difference = characterOne.transform.position - characterTwo.transform.position;
        float xDistance = difference.x;

        if (Mathf.Abs(xDistance) > 10f) {
            CapMovement(xDistance);
        } else {
            UncapMovement();
        }
    }

    private void CapMovement(float xDirection) {
        if (xDirection > 0) {
            controllerOne.CapRight();
            controllerTwo.CapLeft();
        } else {
            controllerOne.CapLeft();
            controllerTwo.CapRight();
        }
    }

    private void UncapMovement() {
        controllerOne.UncapMovement();
        controllerTwo.UncapMovement();
    }
}
