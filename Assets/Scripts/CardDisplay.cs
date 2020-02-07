using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : CardFrontContainer {

    public override void AddCard(List<Card> cards) {
        foreach (Card card in cards) {
            this.cards.Add(card);
            Transform c = Instantiate(cardTemplate.transform, transform.position, transform.rotation);
            c.localScale *= 8;
            c.SetParent(transform, true);
        }
    }
}
