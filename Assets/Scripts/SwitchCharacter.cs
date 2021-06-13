using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    [SerializeField] private GameObject characterOne;
    [SerializeField] private GameObject characterTwo;
    private Controller controllerOne;
    private Controller controllerTwo;

    [SerializeField] private bool characterOneStarts = true;
    private bool characterOneIsActive;

    void Awake() {
        controllerOne = characterOne.GetComponent<Controller>();
        controllerTwo = characterTwo.GetComponent<Controller>();
        characterOneIsActive = characterOneStarts;
    }

    void Start() {
        if (characterOneStarts) {
            controllerOne.SetActive(true);
            controllerTwo.SetActive(false);
        } else {
            controllerOne.SetActive(false);
            controllerTwo.SetActive(true);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            Switch();
        }
    }

    private void Switch() {
        if (characterOneIsActive) {
            controllerOne.SetActive(false);
            controllerTwo.SetActive(true);
            characterOneIsActive = false;
        } else {
            controllerOne.SetActive(true);
            controllerTwo.SetActive(false);
            characterOneIsActive = true;
        }
    }

    public bool GetCharacterOneIsActive() {
        return characterOneIsActive;
    }
}
