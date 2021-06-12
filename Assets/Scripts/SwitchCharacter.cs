using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    [SerializeField] private GameObject characterOne;
    [SerializeField] private GameObject characterTwo;

    [SerializeField] private bool characterOneStart = true;

    private Controller controllerOne;
    private Controller controllerTwo;

    void Awake() {
        controllerOne = characterOne.GetComponent<Controller>();
        controllerTwo = characterTwo.GetComponent<Controller>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            Switch();
        }

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

    private void Switch() {
        controllerOne.ToggleActive();
        controllerTwo.ToggleActive();
    }
}
