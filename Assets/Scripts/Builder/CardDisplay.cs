using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDisplay : CardFrontContainer {

    public TextMeshProUGUI name;

    public void Display(List<Card> cards, string name) {
        AddCard(cards);
        SetName(name);
    }
    public override void AddCard(List<Card> cards) {

        Clear();

        foreach (Card card in cards) {
            this.cards.Add(card);
            cardTemplate.card = card;
            Transform c = Instantiate(cardTemplate.transform, transform.position, transform.rotation);
            c.localScale *= 8;
            c.SetParent(transform, true);
        }
    }

    public void SetName(string name) {
        this.name.text = name;
    }

    public void Clear() {
        Empty();
        SetName("");
    }
}
