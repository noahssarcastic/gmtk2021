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
    private bool characterOneActive;

    void Awake() {
        controllerOne = characterOne.GetComponent<Controller>();
        controllerTwo = characterTwo.GetComponent<Controller>();
        characterOneActive = characterOneStarts;
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
            Debug.Log("switch");
        }
    }

    private void Switch() {
        if (characterOneActive) {
            controllerOne.SetActive(false);
            controllerTwo.SetActive(true);
            characterOneActive = false;
        } else {
            controllerOne.SetActive(true);
            controllerTwo.SetActive(false);
            characterOneActive = true;
        }
    }

    public bool GetCharacterOneActive() {
        return characterOneActive;
    }
}
