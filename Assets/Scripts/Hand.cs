using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : CardFrontContainer {

    public void RemoveCard(Card card) {
        cards.Remove(card);
    }

}
