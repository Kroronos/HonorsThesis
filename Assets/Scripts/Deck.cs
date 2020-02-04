using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : CardBackContainer
{

    public PlayerClass playerClass;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Card card in playerClass.startingCards) {
            cards.Add(card);
            Transform c = Instantiate(cardBack, transform.position, cardBack.rotation);
            c.SetParent(transform, true);
        }

    }

    public void Shuffle() {
        AddCard(CardController.cardController.RetrieveDiscard());

        //Fisher-Yates Shuffle
        System.Random random = new System.Random();

        for(int i = 0; i < cards.Count-1; ++i) {
            int randIndex = i + random.Next(cards.Count-i);

            Card sel = cards[randIndex];
            
            //swap
            cards[randIndex] = cards[i];
            cards[i] = sel;
        }
    }

    public List<Card> Draw(int drawSize = 5) {

        List<Card> drawnCards = new List<Card>();

        if (drawSize == 0)
            return new List<Card>();


        if(cards.Count < drawSize) {
            int cardCount = cards.Count;
            drawnCards = Draw(cards.Count);

            Shuffle();

            int drawAmount = (drawSize - cardCount < cards.Count) ? drawSize - cardCount : cards.Count;
            drawnCards.AddRange(Draw(drawAmount));

            return drawnCards;
        }
        else {

            int oldChildCount = transform.childCount;

            for (int i = drawSize-1; i >= 0; --i) {
                Card accessed = cards[i];
                cards.RemoveAt(i);

                Destroy(transform.GetChild(oldChildCount - i - 1).gameObject);
                
                drawnCards.Add(accessed);
            }
            
            return drawnCards;

        }


    }
}
