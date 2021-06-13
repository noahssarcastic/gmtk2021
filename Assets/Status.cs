using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField] private float courage = 100;

    public float GetCourage() {
        return courage;
    }

    public void SetCourage(float value) {
        courage = value;
    }
}
