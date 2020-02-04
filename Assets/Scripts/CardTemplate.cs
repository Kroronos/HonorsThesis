using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CardTemplate : MonoBehaviour, IPointerClickHandler {
    public Card card;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI costText;
    public Image artImage;


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

    public void OnPointerClick(PointerEventData pointerEventData) {
        if (pointerEventData.button == PointerEventData.InputButton.Left) {
            Debug.Log("Selected card" + card.cardName);

            CardManager.singleton.SetSelected(card);

        }

        if (pointerEventData.button == PointerEventData.InputButton.Right) {
            Debug.Log("Deselected" + card.cardName);

            CardManager.singleton.SetSelected(null);
        }
        
    }


}
