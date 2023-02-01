using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarSlider : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxValue(int barValue)
    {
        slider.maxValue = barValue;
        slider.value = barValue;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetBarValue (int barValue)
    {

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
