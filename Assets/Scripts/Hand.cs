using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<Card> cards = new List<Card>();

    public CardTemplate cardTemplate;

    public void AddCard(Card card) {
        cards.Add(card);

        cardTemplate.card = card;

        Vector3 pos = transform.position;
       
        Transform c = Instantiate(cardTemplate.transform);
        c.SetParent(transform, true);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
