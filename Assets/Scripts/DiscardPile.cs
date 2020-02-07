using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiscardPile : CardFrontContainer, IPointerClickHandler {

    public void OnPointerClick(PointerEventData pointerEventData) {

        Debug.Log("Showing deck card display");

        CardController.cardController.cardDisplay.AddCard(cards);

        CardController.cardController.cardDisplay.gameObject.SetActive(true);
    }



}
