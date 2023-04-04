﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatHUD : MonoBehaviour
{
    public Slider hpSlider;

    public void SetHUD(Unit unit)
    {
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        SetHP(unit.currentHP);
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;

        BarSlider barSlider = GetComponentInChildren<BarSlider>();
        barSlider.SetBarValue(hp);
    }
}
