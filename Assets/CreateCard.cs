using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCard : MonoBehaviour
{
    public Card card;

    public Text nameText;
    public Text descriptionText;
    public Text costText;
    public Image artImage;



    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.cardName;
        descriptionText.text = card.description;
        costText.text = card.cost.ToString();

        artImage.sprite = card.art;
        
    }
}
