using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Deck", menuName = "Deck")]
public class DeckListObject : ScriptableObject
{
    [SerializeField]
    private List<Card> deck;

    public List<Card> getDeck(){
        return deck;
    }

}
