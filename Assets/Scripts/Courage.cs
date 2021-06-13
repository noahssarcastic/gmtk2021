using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courage : MonoBehaviour
{
    [SerializeField] private GameObject characterOne;
    private Controller characterOneController;
    private Status characterOneStatus;

    [SerializeField] private GameObject characterTwo;
    private Controller characterTwoController;
    private Status characterTwoStatus;

    [SerializeField] private CourageBar courageBar;

    private SwitchCharacter switchCharacter;

    [SerializeField] private float maxDistance = 15; 

    private const float baseCourage = 100;

    void Awake() {
        characterOneController = characterOne.GetComponent<Controller>();
        characterOneStatus = characterOne.GetComponent<Status>();
        characterTwoController = characterTwo.GetComponent<Controller>();
        characterTwoStatus = characterTwo.GetComponent<Status>();
        switchCharacter= GetComponent<SwitchCharacter>();
    }

    void Update() {
        Vector3 characterOnePosition = characterOne.transform.position;
        Vector3 characterTwoPosition = characterTwo.transform.position;
        Vector3 difference = characterOnePosition - characterTwoPosition;
        // We only care about x
        float distance = Mathf.Abs(difference.x);
        float direction = difference.x;

        if (AreLonely(distance)) {
            CapMovement(direction);
        } else {
            UncapMovement();
        }
    }

    private bool AreLonely(float distance) {
        float courageModifier;
        if (switchCharacter.GetCharacterOneIsActive()) {
            courageModifier = characterOneStatus.GetCourageModifier();
        } else {
            courageModifier = characterTwoStatus.GetCourageModifier();
        }

        // Set max courage to modifier of active character
        courageBar.SetMaxCourage(baseCourage * courageModifier);

        // Lonliness (how far the dogs are) is capped between 0 and 1
        float loneliness = distance / (maxDistance * courageModifier);
        courageBar.SetCourage(1-loneliness);
        return loneliness >= 1;
    }

    private void CapMovement(float direction) {
        if (direction > 0) {
            characterOneController.CapRight();
            characterTwoController.CapLeft();
        } else {
            characterOneController.CapLeft();
            characterTwoController.CapRight();
        }
    }

    private void UncapMovement() {
        characterOneController.UncapMovement();
        characterTwoController.UncapMovement();
    }
}
