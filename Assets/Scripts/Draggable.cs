using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("Beginning to drag");
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("Dragging");

        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));

    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("Ending drag");
    }
}
