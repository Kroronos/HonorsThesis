using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public Deck deck;
    public Hand hand;
    public DiscardPile discard;

    void Start() {

        foreach (Card card in deck.Draw(4))
            hand.AddCard(card);
    
    }
    

}
