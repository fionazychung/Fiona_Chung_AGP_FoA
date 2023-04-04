using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum CombatState { START, ATTACKTURN, DEFENDTURN, WON, LOST }

public class CombatSystem : MonoBehaviour
{
    [Header("Battle Units")]
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;

    public MainMenuController MainMenuControl;

    [Header("Display Reference")]
    [SerializeField] private CombatHUD combatHUD;
    [SerializeField] private HandCardManager handCardManager;

    private bool canSelectHandCard = false;
    private bool haveSelectedCard = false;
    private CombatState state;
    private CardUnit currentCardUnit = null;

    void Start()
    {
        state = CombatState.START;

        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        //Setup enemy
        enemyUnit.LoadNewCard(GameData.instance.currentEnemyCard);

        //Random Attack or Defend at the start
        if (Random.Range(0, 2) == 0)
            state = CombatState.ATTACKTURN;
        else
            state = CombatState.DEFENDTURN;

        GameData.instance.currentPlayerCard = null;
        GameData.instance.lastPlayedCard = null;

        combatHUD.SetHUD();
        combatHUD.DisplayTurnVisuals(state);

        handCardManager.SetCards();

        yield return new WaitForSeconds(2f);
        canSelectHandCard = true;
    }

    public void ClickedOnCardHand(CardUnit cardUnit)
    {
        if (!canSelectHandCard)
        {
            Debug.Log("Cannot currently select Card");
            return;
        }

        GameData.instance.currentPlayerCard = cardUnit.card;
        haveSelectedCard = true;

        // Updating the Unit Player
        currentCardUnit = cardUnit;
        playerUnit.LoadNewCard(cardUnit.card);
    }

    public void PlayTheTurnButtonPress()
    {
        if (handCardManager.HaveActiveCards())
        {
            if (!haveSelectedCard)
            {
                Debug.Log("Cannot Play yet, Select a Card");
                return;
            }
        }

        haveSelectedCard = false;
        canSelectHandCard = false;

        StartCoroutine(PlayCurrentTurn());
    }

    IEnumerator PlayCurrentTurn()
    {
        //Todo: Check For Special Attack or Suit NOW

        Card attackCard = currentCardUnit ? currentCardUnit.card : new Card();
        int result;

        if (state == CombatState.ATTACKTURN)
        {
            result = attackCard.attack - GameData.instance.currentEnemyCard.defense;
        }
        else
        {
            result = attackCard.defense - GameData.instance.currentEnemyCard.attack;
        }

        bool enemyIsDead = false;
        bool isPlayerDead = false;

        switch (result)
        {
            case > 0:
                //* Enemy Takes Damage
                enemyIsDead = enemyUnit.TakeDamage(result);
                break;
            case 0:
                //* No One Takes Damage
                break;
            case < 0:
                //* Player Takes Damage
                isPlayerDead = playerUnit.TakeDamage(-result);
                break;
        }

        combatHUD.UpdateHUD(playerUnit.currentHP, enemyUnit.currentHP);
        yield return new WaitForSeconds(1f);

        handCardManager.UpdateCardsTurn(currentCardUnit);

        currentCardUnit = null;
        playerUnit.ResetCardToDefault();


        if (enemyIsDead)
        {
            state = CombatState.WON;
            EndBattle();
        }
        else if (isPlayerDead)
        {
            state = CombatState.LOST;
            EndBattle();
        }
        else
        {
            ChangeState();
            combatHUD.DisplayTurnVisuals(state);

            GameData.instance.lastPlayedCard = GameData.instance.currentPlayerCard;

            yield return new WaitForSeconds(2f);
            canSelectHandCard = true;
        }
    }

    void EndBattle()
    {
        if (state == CombatState.WON)
        {
            Debug.Log("YOU WON");
            //TODO Unlock enemyCard in Deck
            GameData.instance.AddCardToDeck(enemyUnit.GetCard());

            MainMenuControl.StageSelect();
        }
        else if (state == CombatState.LOST)
        {
            Debug.Log("YOU LOST");

            MainMenuControl.StageSelect();

        }
    }

    // Method Helper
    void ChangeState()
    {
        if (state == CombatState.ATTACKTURN)
            state = CombatState.DEFENDTURN;
        else
            state = CombatState.ATTACKTURN;
    }
}
