using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public static CardController cardController;

    public Deck deck;
    public Hand hand;
    public DiscardPile discard;

    private Card selectedCard;

    void Awake() {
        if(cardController == null) {
            cardController = this;
        }
        else {
            Debug.LogError("More than one card controller in application.");
        }
    }

    void Start() {

        foreach (Card card in deck.Draw(4))
            hand.AddCard(card);
    
    }

    public Card GetSelected() {
        return selectedCard;
    }

    public void SetSelected(Card selection) {
        selectedCard = selection;
    }
    

}
