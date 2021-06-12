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
    }

    private void Switch() {
        controllerOne.ToggleActive();
        controllerTwo.ToggleActive();
    }
}
