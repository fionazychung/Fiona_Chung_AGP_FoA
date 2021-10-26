using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxValue = 20;
    public int currentValue;

    public BarSlider barSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentValue = maxValue;
        barSlider.SetMaxValue(maxValue);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MinusValue(5);
        }
    }

    void MinusValue(int minus)
    {
        currentValue -= minus;

        barSlider.SetBarValue(currentValue);
    }
}
