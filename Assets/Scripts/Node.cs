using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Renderer rend;

    private Color defaultColor;
    private Color selectedColor;

    void Start() {
        rend = GetComponent<Renderer>();

        defaultColor = Color.white;
        selectedColor = Color.magenta;
    }

    void OnMouseEnter() {
        if(CardController.cardController.GetSelectedCard() is TurretCard) {
            rend.material.color = selectedColor;
        }
    }

    void OnMouseDown() {
        if (CardController.cardController.GetSelectedCard() is TurretCard && CardController.cardController.CanAffordSelected()) {
            Turret buildTurret = ((TurretCard)CardController.cardController.GetSelectedCard()).turret;
            Transform turret = Instantiate(buildTurret.transform, transform.position, transform.rotation);
            turret.SetParent(transform, true);

            CardController.cardController.UseCard();
        }
    }

    void OnMouseExit() {
        rend.material.color = defaultColor;
    }
}
