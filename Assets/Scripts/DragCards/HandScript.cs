using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandScript
{
    public HandScript()
    {
        hand = new List<HandCardDisplay>();
        maxHandSize = 4;
    }

    private List<HandCardDisplay> hand;
    private int maxHandSize;

    public void AddCard(HandCardDisplay card)
    {
        hand.Add(card);
    }
    public int GetMaxHandSize()
    {
        return maxHandSize;
    }


}
