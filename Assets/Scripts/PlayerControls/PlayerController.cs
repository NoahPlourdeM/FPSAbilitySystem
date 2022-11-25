using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   private PlayerInput _playerInput;
   [SerializeField] private Camera playerCam;

   private Rigidbody rb;

   private Vector2 currentMovement;
   private bool movementPressed;

   private Vector2 mouseLook;
   private float xRotation;
   public PlayerInputActions playerInputActions;

   [SerializeField] private float speed = 1;
   [SerializeField] private float mouseSensitivity = 1;

   private void Awake()
   {
      rb = transform.GetComponent<Rigidbody>();
      
      _playerInput = GetComponent<PlayerInput>();

      playerInputActions = new PlayerInputActions();
      playerInputActions.Player.Enable();
      
      playerInputActions.Player.Jump.performed += Jump;
      playerInputActions.Player.Movement.performed += ctx =>
      {
         currentMovement = ctx.ReadValue<Vector2>();
         movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
      };

      playerInputActions.Player.Look.performed += Look;

      Cursor.lockState = CursorLockMode.Locked;
   }

   private void Update()
   {
      Movement();
   }

   private void Look(InputAction.CallbackContext context)
   {
      mouseLook = playerInputActions.Player.Look.ReadValue<Vector2>();
      float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime;
      float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;

      xRotation -= mouseY;
      xRotation = Mathf.Clamp(xRotation, -90f, 90);
      
      playerCam.transform.localRotation = Quaternion.Euler(xRotation,0,0);
      transform.Rotate(Vector3.up * mouseX);
      Debug.Log("Looking " + context.phase);
   }
   
   public void Movement()
   {
      if (movementPressed)
      {
         rb.velocity = ((currentMovement.y * transform.forward) +  (currentMovement.x * transform.right)) * speed;
      }
   }

   public void Jump(InputAction.CallbackContext context){
      if (context.performed)
      {
         //Debug.Log("Jump " + context.phase);
      }
   }
}
