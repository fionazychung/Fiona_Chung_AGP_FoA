using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum CombatState { START, ATTACKTURN, DEFENDTURN, WON, LOST }

public class CombatSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public PlayerCardUsageSystem playerCardUsageSystem;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public Unit playerUnit;
    public Unit enemyUnit;

    //public Text dialogueText;

    public CombatHUD playerHUD;
    public CombatHUD enemyHUD;

    public CombatState state;
    public CardDisplay playerCardDisplay;
    public CardDisplay enemyCardDisplay;
    public Card selectedCard;

    [SerializeField]
    private DeckListObject deckList;
    private DeckScript deck;
    private HandScript hand;

    public TMP_Text turnText;
    public Image attackTurnImage;
    public Image defeneseTurnImage;
    

    void Start()
    {
        state = CombatState.START;
        StartCoroutine(SetupBattle());

        deck = new DeckScript(deckList);
        hand = new HandScript();
    }

    void DisplayTurn()
    {
        if (state == CombatState.ATTACKTURN)
        {
            turnText.text = "ATTACK";
            attackTurnImage.enabled = true;
            defeneseTurnImage.enabled = false;
        }
        else
        {
            turnText.text = "DEFEND";
            defeneseTurnImage.enabled = true;
            attackTurnImage.enabled = false;
        }
    }

    IEnumerator SetupBattle()
    {
        int turn = Random.Range(0, 2);
        if (turn == 0)
        {
            state = CombatState.ATTACKTURN;
        }
        else
        {
            state = CombatState.DEFENDTURN;
        }
        /*GameObject 
        Card cardSetup = deck.SetupCards();*/

        //GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        //playerUnit = playerGO.GetComponent<Units>();

        //GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        //enemyUnit = enemyGO.GetComponent<Units>();

        //dialogueText.text = " " + enemyUnit.unitName + " ";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        DisplayTurn();
        yield return new WaitForSeconds(2f);
        
    }

    IEnumerator PlayerAttack()
    {
        playerCardDisplay.CopyCardAttack();
        enemyCardDisplay.CopyEnemyDefense();

        //print (playerCardDisplay.playerAttackValue);

        int result = playerCardDisplay.playerAttackValue - enemyCardDisplay.enemyDefenseValue;
        bool isDead = false;
        bool isPlayerDead = false;

        if (result > 0)
        {
            Debug.Log("attack successful enemy takes damage");
            isDead = enemyUnit.TakeDamage(playerUnit.damage);
        }
        else if (result < 0)
        {
            Debug.Log("attack unsuccessful player takes damage");
            isPlayerDead = playerUnit.TakeDamage(enemyUnit.damage);
        }

        enemyHUD.SetHP(enemyUnit.currentHP);
        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = CombatState.WON;
            turnText.text = "You Won!";
            EndBattle();
        }
        else if (isPlayerDead)
        {
            state = CombatState.LOST;
            turnText.text = "You Lost";
            EndBattle();
        }
        else
        {
            state = CombatState.DEFENDTURN;
            DisplayTurn();
        }
    }

    IEnumerator PlayerDefend()
    {
        //dialogueText.text = enemyUnit.unitName + " attacks!";
        playerCardDisplay.CopyCardDefense();
        playerCardDisplay.CopyEnemyAttack();

        int result = playerCardDisplay.playerDefenseValue - enemyCardDisplay.enemyAttackValue;

        bool isDead = false;
        bool isPlayerDead = false;

        if (result > 0)
        {
            Debug.Log("defense successful enemy takes damage");
            isDead = enemyUnit.TakeDamage(playerUnit.damage);
        }
        else if (result < 0)
        {
            Debug.Log("defense unsuccessful player takes damage");
            isPlayerDead = playerUnit.TakeDamage(enemyUnit.damage);
        }

        enemyHUD.SetHP(enemyUnit.currentHP);
        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = CombatState.WON;
            turnText.text = "You Won!";
            EndBattle();
        }
        else if (isPlayerDead)
        {
            state = CombatState.LOST;
            turnText.text = "You Lost";
            EndBattle();
        }
        else
        {
            state = CombatState.ATTACKTURN;
            DisplayTurn();
        }

    }

    void EndBattle()
    {
        if (state == CombatState.WON)
        {
            //dialogueText.text = "You won the battle!";
            Debug.Log("YOU WON");
        }
        else if (state == CombatState.LOST)
        {
            //dialogueText.text = "You were defeated.";
            Debug.Log("YOU LOST");
        }
    }

    void PlayerTurn()
    {
        //dialogueText.text = "Choose an action:";

        if (state == CombatState.ATTACKTURN)
        {
            StartCoroutine(PlayerAttack());
        }
        else
        {
            StartCoroutine(PlayerDefend());
        }
    }


    public void OnPlayerTurn()
    {
        PlayerTurn();
        playerCardUsageSystem.EndTurn();
    }


}
