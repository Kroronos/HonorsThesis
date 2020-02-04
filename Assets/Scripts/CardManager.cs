using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    public static CardManager singleton;

    void Awake() {
        if(singleton != null) {
            Debug.LogError("More than one CardManager");
        }
        else {
            singleton = this;
        }
    }

    private Card selectedCardObjectRef;

    public Card GetSelected() {
        return selectedCardObjectRef;
    }

    public void SetSelected(Card selection) {
        selectedCardObjectRef = selection;
    }
}
