using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : CardFrontContainer {

    void Awake() {
        cardTemplate.inHand = true;
    }
    public void RemoveCard(Card card) {
        cards.Remove(card);
    }

    public override void AddCard(Card card) {
        cards.Add(card);

        cardTemplate.card = card;
        Transform c = Instantiate(cardTemplate.transform);
        c.SetParent(transform, false);
    }

    public override void AddCard(List<Card> cards) {
        foreach (Card card in cards) {
            this.cards.Add(card);
            Transform c = Instantiate(cardTemplate.transform);
            c.SetParent(transform, false);
        }
    }

}
