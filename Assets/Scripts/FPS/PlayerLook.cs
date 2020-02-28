using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;
    private float minAngle = -90f, maxAngle = 90f;
    private float xAxisClamp;

    private Transform playerBody;

    void Start()
    {
        playerBody = transform.parent.transform;
        xAxisClamp = 0f;
        LookCursor();
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;
        xAxisClamp = Mathf.Clamp(xAxisClamp, minAngle, maxAngle);
        if (Mathf.Abs(xAxisClamp) == maxAngle) { mouseY = 0f; LimitRotation(xAxisClamp); }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void LimitRotation (float currAngle)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = (currAngle == maxAngle) ? 270f : 90f;
        transform.eulerAngles = eulerRotation;
    }

    private void LookCursor ()
    {
        //Confine cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
    }
}
