using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

[CreateAssetMenu(fileName = "NewPlayerClass", menuName = "PlayerController")]
public class PlayerController : MonoBehaviour
{
    #region Private Variables
    //Variables
    [SerializeField] private float mouseSensitivity;
    //Input System
    private PlayerFPS input;
    private Vector2 movementInput, lookPosition;
    private bool shoot, reload;
    #endregion

    void Awake()
    {
        input = new PlayerFPS();
        input.PlayerInput.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        input.PlayerInput.Rotation.performed += ctx => Rotate(ctx.ReadValue<Vector2>());
        input.PlayerInput.Shoot.performed += ctx => Shoot();
        input.PlayerInput.Reload.performed += ctx => Reload();
    }

    private void OnEnable()
    {
        input.PlayerInput.Enable();
    }

    private void OnDisable()
    {
        input.PlayerInput.Disable();
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
        movementInput = val;
        Debug.Log("Movement: "+ movementInput.x);
    }

    private void Update()
    {
        gameObject.transform.Rotate(Vector3.up * movementInput.x * mouseSensitivity * Time.deltaTime);
    }

    private void LateUpdate()
    {
        //Reset Input Variables
        movementInput = Vector2.zero;
        lookPosition = Vector2.zero;
        shoot = false;
        reload = false;
    }
}
