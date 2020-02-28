using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiscardPile : CardFrontContainer, IPointerClickHandler {

    public void OnPointerClick(PointerEventData pointerEventData) {

        Debug.Log("Showing discard card display");

        CardController.cardController.cardDisplayCanvas.gameObject.SetActive(true);
        CardController.cardController.cardDisplay.Display(cards, "Discard Pile");


    }



}
