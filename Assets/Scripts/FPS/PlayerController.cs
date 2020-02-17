using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

/// <summary>
/// 
/// TODO:
///     - Crouching
/// 
/// </summary>

public class PlayerController : MonoBehaviour
{
    #region Private Variables
    //Variables
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float lookSmoothness = 0.1f;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityModifier;
    private bool isGrounded;
    private Rigidbody rb;
    //Input System
    private PlayerFPS input;
    private Vector2 movementInput, lookRotation;
    //Gun
    private GunController gunController;
    #endregion

    #region Public Variables
    public Gun defaultGun;
    #endregion

    void Awake()
    {
        input = new PlayerFPS();
        //Register Actions
        input.PlayerInput.Shoot.performed += ctx => Shoot(ctx.ReadValue<float>());
        input.PlayerInput.Reload.performed += ctx => Reload();
        input.PlayerInput.Jump.performed += ctx => Jump(ctx.ReadValue<float>());

        Cursor.visible = false;
    }

    private void Start()
    {
        InitializeVariables ();
        InitializeGun();
    }

    private void InitializeVariables()
    {
        isGrounded = false;
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        lookRotation = new Vector2(currentRotation.x, currentRotation.y);
        rb = GetComponent<Rigidbody>();
        gunController = GetComponent<GunController>();
    }

    private void InitializeGun ()
    {
        gunController.InstantiateGun(transform, defaultGun);
    }

    private void OnEnable()
    {
        input.PlayerInput.Enable();
    }

    private void OnDisable()
    {
        input.PlayerInput.Disable();
    }

    private void FixedUpdate()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Move();
        rb.AddForce(new Vector3(0f, -9.8f * gravityModifier, 0f));
    }

    private void Shoot (float val) 
    {
        Debug.Log("Shooting Value: " + val);
        gunController.Shoot((val == 1) ? true : false);
    }

    private void Reload ()
    {
        gunController.Reload();
    }
    
    private void Jump (float pressed)
    {
        if (isGrounded && pressed == 1f)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    private void Move ()
    {
        //Movement
        movementInput = input.PlayerInput.Move.ReadValue<Vector2>();
        if (movementInput != Vector2.zero)
        {
            Vector3 moveForce = new Vector3(movementInput.x, 0f, 0f);
            moveForce = transform.TransformDirection(moveForce);
            Vector3 finalPosition = transform.position;
            finalPosition += Camera.main.transform.forward * moveSpeed * Time.deltaTime * movementInput.y;
            finalPosition += Camera.main.transform.right * moveSpeed * Time.deltaTime * movementInput.x;
            finalPosition.y = transform.position.y;
            transform.position = finalPosition;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor" && !isGrounded)
        {
            isGrounded = true;
            Debug.Log(isGrounded);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor" && isGrounded)
        {
            isGrounded = false;
            Debug.Log(isGrounded);
        }
    }
}
