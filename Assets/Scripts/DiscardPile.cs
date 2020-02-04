using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPile : MonoBehaviour
{

    private List<Card> cards = new List<Card>();
    public CardTemplate cardTemplate;


    public void addCard(Card card) {
        cards.Add(card);

        cardTemplate.card = card;
        Transform c = Instantiate(cardTemplate.transform);
        c.SetParent(transform, true);
    }

    public void addCard(List<Card> cards) {
        foreach(Card card in cards) {
            cards.Add(card);
            Transform c = Instantiate(cardTemplate.transform);
            c.SetParent(transform, true);
        }
    }

    public List<Card> Empty() {
        List<Card> copy = cards;

        cards.Clear();

        foreach(Transform child in transform) {
            Destroy(child.gameObject);
        }

        return copy;
    }
}
