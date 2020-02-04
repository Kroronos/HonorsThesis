using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardContainer : MonoBehaviour
{
    protected List<Card> cards = new List<Card>();

    public abstract void AddCard(Card card);

    public abstract void AddCard(List<Card> cards);
    
    public List<Card> Empty() {
        List<Card> copy = new List<Card>(cards);

        cards.Clear();

        for (int i = 0; i < transform.childCount; ++i) {
            Destroy(transform.GetChild(i).gameObject);
        }

        return copy;
    }
}



public class CardFrontContainer: CardContainer {

    public CardTemplate cardTemplate;

    public override void AddCard(Card card) {
        cards.Add(card);

        cardTemplate.card = card;
        Transform c = Instantiate(cardTemplate.transform);
        c.SetParent(transform, true);
    }

    public override void AddCard(List<Card> cards) {
        foreach (Card card in cards) {
            this.cards.Add(card);
            Transform c = Instantiate(cardTemplate.transform);
            c.SetParent(transform, true);
        }
    }
}

public class CardBackContainer : CardContainer {
    
    public Transform cardBack;


    public override void AddCard(Card card) {
        cards.Add(card);
        Transform c = Instantiate(cardBack, transform.position, cardBack.rotation);
        c.SetParent(transform, true);
    }

    public override void AddCard(List<Card> cards) {
        foreach (Card card in cards) {
            this.cards.Add(card);
            Transform c = Instantiate(cardBack, transform.position, cardBack.rotation);
            c.SetParent(transform, true);
        }
    }
}