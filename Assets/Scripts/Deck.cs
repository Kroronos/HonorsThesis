using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    public PlayerClass playerClass;
    private List<Card> cards = new List<Card>();

    public Transform cardBack;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Card card in playerClass.startingCards) {
            cards.Add(card);
        }

        foreach (Card card in cards) {
            Transform c = Instantiate(cardBack, transform.position, cardBack.rotation);
            c.SetParent(transform, true);
        }
    }

    public void Shuffle() {

    }

    public List<Card> Draw(int drawSize = 5) {

        List<Card> drawnCards = new List<Card>();

        if (drawSize == 0)
            return null;


        if(cards.Count < drawSize) {
            drawnCards = Draw(cards.Count);
            Shuffle();
            drawnCards.AddRange(Draw(drawSize - cards.Count));

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
