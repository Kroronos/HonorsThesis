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
        if(CardManager.singleton.GetSelected() is TurretCard) {
            rend.material.color = selectedColor;
        }
    }

    void OnMouseDown() {
        if (CardManager.singleton.GetSelected() is TurretCard) {
            Turret buildTurret = ((TurretCard)CardManager.singleton.GetSelected()).turret;
            Transform turret = Instantiate(buildTurret.transform, transform.position, transform.rotation);
            turret.SetParent(transform, true);
        }
    }

    void OnMouseExit() {
        rend.material.color = defaultColor;
    }
}
