using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    public List<Card> cards = new List<Card>();

    public CardTemplate cardTemplate;

    public void AddCard(Card card) {
        cards.Add(card);

        cardTemplate.card = card;

        Vector3 pos = transform.position;

        Transform c = Instantiate(cardTemplate.transform);
        c.SetParent(transform, true);

    }

    public void RemoveCard(Card card) {
        cards.Remove(card);
    }

    public List<Card> Empty() {
        List<Card> copy = new List<Card>(cards);

        cards.Clear();

        for (int i = 0; i < transform.childCount; ++i) {
            Destroy(transform.GetChild(i).gameObject);
        }

        return copy;
    }
}
