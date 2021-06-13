using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CourageBar : MonoBehaviour
{
    private Slider slider;
    private RectTransform barTransform;
    private float defaultWidth;

    private const float baseCourage = 100;

    void Awake() {
        slider = GetComponent<Slider>();
        barTransform = GetComponent<RectTransform>();
        defaultWidth = barTransform.transform.localScale.x;
    }

    public void SetCourage(float percent) {
        // cap percent between 0 and 1
        if (percent < 0) {
            percent = 0;
        } else if (percent > 1) {
            percent = 1;
        }
        slider.value = slider.maxValue * percent;
    }

    public void SetMaxCourage(float value) {
        // cap value between 50 and 200
        if (value < 50) {
            value = 50;
        } else if (value > 200) {
            value = 200;
        }
        slider.maxValue = value;
        barTransform.localScale = new Vector3(
            defaultWidth * (value / baseCourage), 
            barTransform.localScale.y, 
            barTransform.localScale.z);
    }
}
