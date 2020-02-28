using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardController : MonoBehaviour
{
    public static CardController cardController;
    public CardDisplay cardDisplay;

    public Canvas cardDisplayCanvas;


    public Deck deck;
    public Hand hand;
    public DiscardPile discard;

    public int baseResources = 3;
    public static int resources;
    public TextMeshProUGUI resourceText;

    private CardTemplate selectedCard;

    void Awake() {
        if(cardController == null) {
            cardController = this;
        }
        else {
            Debug.LogError("More than one card controller in application.");
        }

        resources = baseResources;
        resourceText.text = "Resources: " + resources;
        cardDisplayCanvas.gameObject.SetActive(false);
    }

    void Start() {

        deck.DeckStart();

        foreach (Card card in deck.Draw(4))
            hand.AddCard(card);
    
    }

    void Update() {
        resourceText.text = "Resources: " + resources;
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
        else if(CanAffordCard(selection.card)) {
            
            if (selectedCard == null) {
                selection.setIndicator();
            }
            else {
                selectedCard.releaseIndicator();
                selection.setIndicator();
            }
        }
        else {
            Debug.Log("Cannot afford selection"); //@TODO make ui popup
            return;
        }


        selectedCard = selection;
    }

    public bool CanAffordSelected() {
        if(selectedCard && CanAffordCard(selectedCard.card)) {
            return true;
        }
        return false;
    }

    private bool CanAffordCard(Card card) {
        if (card.cost <= resources) {
            return true;
        }
        else return false; 
    }

    public void UseResource(Card card) {
        resources -= card.cost;
        resourceText.text = "Resources: " + resources;
    }

    public void UseCard() {
        if (selectedCard) {
            UseResource(selectedCard.card);
            discard.AddCard(selectedCard.card);
            selectedCard.releaseIndicator();
            hand.RemoveCard(selectedCard.card);
            Destroy(selectedCard.gameObject);
            selectedCard = null;
        }
        
    }

    public List<Card> RetrieveDiscard() {
        if(discard != null)
            return discard.Empty();

        return new List<Card>();
    }

    public void EndTurn() {
        
        resources = baseResources;

        SetSelected(null);

        //TODO COMMENTED FOR TESTING PURPOSES
        //discard.AddCard(hand.Empty());

        foreach (Card card in deck.Draw(4))
            hand.AddCard(card);
    }
    

}
