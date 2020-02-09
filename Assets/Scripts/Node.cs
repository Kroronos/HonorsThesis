using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    private Renderer rend;

    private Turret builtTurret;
    private Transform displayTurret;

    private Color defaultColor;
    private Color selectedColor;

    void Start() { 

        builtTurret = null;
        displayTurret = null;

        rend = GetComponent<Renderer>();

        defaultColor = Color.white;
        selectedColor = Color.magenta;
    }

    void Update() {

    }

    void OnMouseEnter() {
        if(!BuildingManager.buildingManager.InProgress() && builtTurret == null) {
            rend.material.color = selectedColor;

            /*Turret disp = ((TurretCard)CardController.cardController.GetSelectedCard()).turret;
            displayTurret = Instantiate(disp.transform, transform.position, transform.rotation);
            displayTurret.SetParent(transform, true);*/
        }
    }

    void OnMouseDown() {

        if (CardController.cardController.GetSelectedCard() is TurretCard
            && CardController.cardController.CanAffordSelected()
            && builtTurret == null) {

            if (displayTurret != null)
                Destroy(displayTurret.gameObject);

           /* builtTurret = ((TurretCard)CardController.cardController.GetSelectedCard()).turret;
            Transform turret = Instantiate(builtTurret.transform, transform.position, transform.rotation);
            turret.SetParent(transform, true);



            CardController.cardController.UseCard();
            rend.material.color = defaultColor;*/
        }
    }


    void OnMouseExit() {
        if (displayTurret != null)
            Destroy(displayTurret.gameObject);

        if(!BuildingManager.buildingManager.InProgress())
            rend.material.color = defaultColor;
    }
}
