using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public static CardController cardController;

    public Deck deck;
    public Hand hand;
    public DiscardPile discard;

    private CardTemplate selectedCard;

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

    public Card GetSelectedCard() {
        if(selectedCard)
            return selectedCard.card;
        return null;
    }

    public void SetSelected(CardTemplate selection) {
        if(selection == null) {
            if (selectedCard) {
                selectedCard.releaseIndicator();

            }
        }
        else if(selectedCard == null) {
            selection.setIndicator();
        }
        else {
            selectedCard.releaseIndicator();
            selection.setIndicator();
        }

        selectedCard = selection;
    }
    

}
