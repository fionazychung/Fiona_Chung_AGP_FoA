using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
Shows UI for Combat:
HP for both player + enemy
Turn states visuals
*/
public class CombatHUD : MonoBehaviour
{
    [Header("Sliders Reference")]
    [SerializeField] private Slider playerHpSlider;
    [SerializeField] private Slider enemyHpSlider;
    [SerializeField] private Gradient gradientLifeColor;

    [Header("State Reference")]
    [SerializeField] private Image stateImage;
    [SerializeField] private TextMeshProUGUI stateText;
    [SerializeField] private Sprite attackSprite;
    [SerializeField] private Sprite defenseSprite;

    private Image playerFill;
    private Image enemyFill;

    private void Start()
    {
        playerFill = playerHpSlider.GetComponentInChildren<Image>();
        enemyFill = enemyHpSlider.GetComponentInChildren<Image>();
    }

    public void SetHUD()
    {
        playerFill.color = gradientLifeColor.Evaluate(playerHpSlider.normalizedValue);
        enemyFill.color = gradientLifeColor.Evaluate(enemyHpSlider.normalizedValue);
    }

    public void UpdateHUD(int playerHp, int enemyHp)
    {
        playerHpSlider.value = playerHp;
        enemyHpSlider.value = enemyHp;

        playerFill.color = gradientLifeColor.Evaluate(playerHpSlider.normalizedValue);
        enemyFill.color = gradientLifeColor.Evaluate(enemyHpSlider.normalizedValue);
    }

    public void DisplayTurnVisuals(CombatState state)
    {
        stateImage.sprite = state == CombatState.ATTACKTURN ? attackSprite : defenseSprite;
        stateText.text = state == CombatState.ATTACKTURN ? "Attack" : "Defense";
    }
}