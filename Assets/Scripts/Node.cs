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
        rend.material.color = selectedColor;
    }

    void OnMouseExit() {
        rend.material.color = defaultColor;
    }
}
