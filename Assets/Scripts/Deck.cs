using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Deck : CardBackContainer, IPointerClickHandler {

    public PlayerClass playerClass;

    // Start is called before the first frame update
    public void DeckStart()
    {
        foreach(Card card in playerClass.startingCards) {
            AddCard(card);
        }

        Shuffle();

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

            EmptyCheck();

            return drawnCards;
        }
        else {

            for (int i = drawSize - 1; i >= 0; --i) {
                Card accessed = cards[i];
                cards.RemoveAt(i);
                drawnCards.Add(accessed);
            }

            EmptyCheck();

            return drawnCards;

        }
    }

    public void OnPointerClick(PointerEventData pointerEventData) {

        Debug.Log("Showing deck card display");
        CardController.cardController.cardDisplayCanvas.gameObject.SetActive(true);
        CardController.cardController.cardDisplay.Display(cards, "Deck");
    }

    private void EmptyCheck() {
        if(cards.Count == 0) {
            for (int i = 0; i < transform.childCount; ++i) {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }



}
