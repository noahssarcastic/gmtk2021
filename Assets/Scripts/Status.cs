using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField] private float courageModifier = 1;

    public float GetCourageModifier() {
        return courageModifier;
    }

    public void SetCourageModifier(float value) {
        courageModifier = value;
    }
}
