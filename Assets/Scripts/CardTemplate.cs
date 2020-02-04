using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CardTemplate : MonoBehaviour, IPointerClickHandler {
    public Card card;
    public GameObject SelectionIndicator;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI costText;
    public Image artImage;

    private Transform SelectionIndicatorInstance;
    public bool inHand;


    // Start is called before the first frame update
    void Start()
    {
        Init(card);

    }

    public void Init(Card c) {
        nameText.text = card.cardName;
        descriptionText.text = card.description;
        costText.text = card.cost.ToString();

        artImage.sprite = card.art;
    }

    
    public void setIndicator() {
        SelectionIndicatorInstance = Instantiate(SelectionIndicator.transform, transform.position, SelectionIndicator.transform.rotation);
    }

    public void releaseIndicator() {
        Destroy(SelectionIndicatorInstance.gameObject);
    }
    
    public void OnPointerClick(PointerEventData pointerEventData) {
        if (pointerEventData.button == PointerEventData.InputButton.Left && inHand) {
            Debug.Log("Selected card" + card.cardName);

            CardController.cardController.SetSelected(this);
        }

        if (pointerEventData.button == PointerEventData.InputButton.Right && inHand) {
            Debug.Log("Deselected" + card.cardName);

            CardController.cardController.SetSelected(null);

        }
        
    }


}
