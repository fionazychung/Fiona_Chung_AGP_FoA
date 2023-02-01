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
    //private DeckListObject deckList;
    private DeckScript deck;
    private HandScript hand;

    public MainMenuController MainMenuControl;

    public TMP_Text turnText;
    public Image attackTurnImage;
    public Image defeneseTurnImage;


    int water;
    int earth;
    int fire;
    int air;


    void Start()
    {

        state = CombatState.START;

        //if level is water 2, randomize enemy out of 3: the high priestess, the empress, the wheel of fortune


        StartCoroutine(SetupBattle());

        //deck = new DeckScript(deckList);
        hand = new HandScript();
        playerUnit.damageMultiplier = 1;
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
         
        //Card cardSetup = deck.SetupCards();

        //set the randomization of enemy card acording to levels 

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        DisplayTurn();
        yield return new WaitForSeconds(2f);
        
    }

    IEnumerator PlayerAttack()
    {
        playerCardDisplay.CopyCardAttack();
        enemyCardDisplay.CopyCardDefense();
        Debug.Log($"player attack {playerCardDisplay.attackValue} enemy defend {enemyCardDisplay.defenseValue}");
        int result = playerCardDisplay.attackValue - enemyCardDisplay.defenseValue;
        bool isDead = false;
        bool isPlayerDead = false;

        if (result > 0)
        {
            //Debug.Log("attack successful enemy takes damage");
            isDead = enemyUnit.TakeDamage(result);
            print(playerUnit.damageMultiplier);
            playerUnit.damageMultiplier = 1;

        }
        else if (result < 0)
        {
            //Debug.Log("attack unsuccessful player takes damage");
            isPlayerDead = playerUnit.TakeDamage(-result);
            FindObjectOfType<AudioManager>().PlaySounds("SFX_HP_Loss_2");
        }

        SuitCounter();

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
        playerCardDisplay.CopyCardDefense();
        enemyCardDisplay.CopyCardAttack();
        Debug.Log($"enemy attack {enemyCardDisplay.attackValue} player defend {playerCardDisplay.defenseValue}");
        int result = playerCardDisplay.defenseValue - enemyCardDisplay.attackValue;

        bool isDead = false;
        bool isPlayerDead = false;

        if (result > 0)
        {
            //Debug.Log("defense successful enemy takes damage");
            isDead = enemyUnit.TakeDamage(result);
            print(playerUnit.damageMultiplier);
            playerUnit.damageMultiplier = 1;
        }
        else if (result < 0)
        {
            //Debug.Log("defense unsuccessful player takes damage");
            isPlayerDead = playerUnit.TakeDamage(-result);
            FindObjectOfType<AudioManager>().PlaySounds("SFX_HP_Loss_2");
        }

        SuitCounter();

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
            GameData.instance.deck.Add(enemyCardDisplay.card);

            MainMenuControl.StageSelect();
        }
        else if (state == CombatState.LOST)
        {
            //dialogueText.text = "You were defeated.";
            Debug.Log("YOU LOST");
            if (GameData.instance.deck.Count > 2)
            {
                GameData.instance.deck.RemoveAt(Random.Range(0, GameData.instance.deck.Count));
            }
            MainMenuControl.StageSelect();

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

    void SuitCounter()
    {
        playerCardDisplay.CopyCardSuit();
        enemyCardDisplay.CopyCardSuit();


        if (playerCardDisplay.suit == "Water")
        {
            water += 1;
            earth = 0;
            fire = 0;
            air = 0;
        }
        if (playerCardDisplay.suit == "Earth")
        {
            earth += 1;
            water = 0;
            fire = 0;
            air = 0;
        }
        if (playerCardDisplay.suit == "Fire")
        {
            fire += 1;
            water = 0;
            earth = 0;
            air = 0;
        }
        if (playerCardDisplay.suit == "Air")
        {
            air += 1;
            water = 0;
            earth = 0;
            fire = 0;
            Debug.Log("aircounter + 1");
        }

        if (water > 1 && enemyCardDisplay.suit == "Earth")
        {
            playerUnit.damageMultiplier = 2;
            //reset
            water = 0;
        }
        if (earth > 1 && enemyCardDisplay.suit == "Fire")
        {
            playerUnit.damageMultiplier = 2;
            earth = 0;
        }
        if (fire > 1 && enemyCardDisplay.suit == "Air")
        {
            playerUnit.damageMultiplier = 2;
            fire = 0;
        }
        print($"{air} {enemyCardDisplay.suit}");
        if (air > 1 && enemyCardDisplay.suit == "Water")
        {
            playerUnit.damageMultiplier = 2;
            air = 0;
            Debug.Log("double damage");
        }


        //make counters for each of the suits, when a suit is played increase by one
        //if the same suit is played again count is 2 and damage is doubled
        //if another suit is played the counter is set to 0 
    }
}
