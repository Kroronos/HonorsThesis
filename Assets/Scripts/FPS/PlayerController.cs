using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

[CreateAssetMenu(fileName = "NewPlayerClass", menuName = "PlayerController")]
public class PlayerController : MonoBehaviour
{

    //Input System
    private PlayerFPS input;
    //Inputs
    private Vector2 movementInput, lookPosition;
    private bool shoot, reload;

    void Awake()
    {
        input = new PlayerFPS();
        input.PlayerInput.Enable();
        input.PlayerInput.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        input.PlayerInput.Rotation.performed += ctx => Rotate(ctx.ReadValue<Vector2>());
        input.PlayerInput.Shoot.performed += ctx => Shoot();
        input.PlayerInput.Reload.performed += ctx => Reload();
    }

    private void Shoot () 
    {
        Debug.Log("Shooting");
    }

    private void Reload ()
    {
        Debug.Log("Reloading");
    }

    private void Move (Vector2 val)
    {
        Debug.Log("Move Value: " + val);
    }

    private void Rotate (Vector2 val)
    {
        Debug.Log("Mouse Value: " + val);
    }
}
