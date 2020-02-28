using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;

    public float scrollSpeed = 2000f;
    public float maxY, minY;

    [SerializeField]
    private KeyCode moveForward = KeyCode.W;

    [SerializeField]
    private KeyCode moveBack = KeyCode.S;

    [SerializeField]
    private KeyCode moveLeft = KeyCode.A;

    [SerializeField]
    private KeyCode moveRight = KeyCode.D;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if(Input.GetKey(moveForward) || Input.mousePosition.y >= Screen.height - panBorderThickness) {
            pos.z += panSpeed * Time.deltaTime;
        }


        if (Input.GetKey(moveBack) || Input.mousePosition.y <= panBorderThickness) {
            pos.z -= panSpeed * Time.deltaTime;
        }


        if (Input.GetKey(moveRight) || Input.mousePosition.x >= Screen.width - panBorderThickness) {
            pos.x += panSpeed * Time.deltaTime;
        }


        if (Input.GetKey(moveLeft) || Input.mousePosition.x <= panBorderThickness) {
            pos.x -= panSpeed * Time.deltaTime;
        }

        pos.y -= Input.mouseScrollDelta.y * scrollSpeed;


        /*pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);*/


        transform.position = pos;
    }
}
