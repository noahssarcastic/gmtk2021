using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CourageBar : MonoBehaviour
{
    private Slider slider;
    private RectTransform barTransform;
    private float defaultXScale;
    private float defaultXPosition;
    private float defaultWidth;

    private const float baseCourage = 100;

    void Awake() {
        slider = GetComponent<Slider>();
        barTransform = GetComponent<RectTransform>();
        defaultXScale = barTransform.transform.localScale.x;
        defaultXPosition = barTransform.transform.position.x;
        defaultWidth = barTransform.rect.width;
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

        float newScale = defaultXScale * (value / baseCourage);
        barTransform.localScale = new Vector3(
            newScale, 
            barTransform.localScale.y, 
            barTransform.localScale.z);

        float newWidth = defaultWidth * newScale;
        float offset = (newWidth - defaultWidth) / 2;
        barTransform.position = new Vector3(
            defaultXPosition + offset,
            barTransform.position.y,
            barTransform.position.z
        );
    }
}
