using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    public List<CardDisplay> deck;
    public List<Card> hand = new List<Card>(4);
    public List<HandCardDisplay> playingHand;

    public HandScript handScript;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        /*if (hand.Count != 0)
        {
            //handScript.AddCard();
            foreach (HandCardDisplay card in hand)
            {
                hand.Add(card);

            }
        }
        else
        {

        }*/
    }
    /*private void Update()
    {
        foreach (HandCardDisplay card in hand)
        {
            hand.Add(card);
        }
    }*/
}
