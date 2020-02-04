using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPile : MonoBehaviour
{

    private List<Card> cards = new List<Card>();
    public CardTemplate cardTemplate;


    public void AddCard(Card card) {
        cards.Add(card);

        cardTemplate.card = card;
        Transform c = Instantiate(cardTemplate.transform);
        c.SetParent(transform, true);
    }

    public void AddCard(List<Card> cards) {
        foreach(Card card in cards) {
            this.cards.Add(card);
            Transform c = Instantiate(cardTemplate.transform);
            c.SetParent(transform, true);
        }
    }

    public List<Card> Empty() {
        List<Card> copy = new List<Card>(cards);

        cards.Clear();

        for(int i = 0; i < transform.childCount; ++i) {
            Destroy(transform.GetChild(i).gameObject);
        }

        return copy;
    }
}
