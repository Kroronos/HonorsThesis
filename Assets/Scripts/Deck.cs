using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    public PlayerClass playerClass;
    private List<Card> cards = new List<Card>();
    public Transform discardPile;
    public Transform cardBack;
    public Transform hand;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Card card in playerClass.startingCards) {
            cards.Add(card);
            Transform c = Instantiate(cardBack, transform.position, cardBack.rotation);
            c.SetParent(transform, true);

        }
    }

    void Shuffle() {

    }

    void DrawHand(int drawSize = 5) {

        if (drawSize == 0)
            return;


        if(cards.Count < drawSize) {
            DrawHand(cards.Count);
            Shuffle();
            DrawHand(drawSize - cards.Count);
        }
        else {
            for (int i = 0; i < drawSize; ++i) {
                Card accessed = cards[i];
                cards.RemoveAt(i);
                Destroy(transform.GetChild(transform.GetChildCount() - 1));
                //@TODO add card to hand
            }
        }


    }
}
