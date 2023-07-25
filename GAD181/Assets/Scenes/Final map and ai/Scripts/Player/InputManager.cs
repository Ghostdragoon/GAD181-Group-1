using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
   private PlayerInput playerInput;
   private PlayerMotor playerMotor;
   private PlayerInput.OnFootActions onFoot;
   private PlayerLook playerLook;
   

   void Awake()
   {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;  
      playerInput = new PlayerInput();
      onFoot = playerInput.OnFoot;
      playerMotor = GetComponent<PlayerMotor>();
      onFoot.Jump.performed += ctx => playerMotor.Jump();
      playerLook = GetComponent<PlayerLook>();
      onFoot.Crouch.performed += ctx => playerMotor.Crouch();
      onFoot.Sprint.performed += ctx => playerMotor.Sprint(); 
   }

   void OnEnable()
   {
      onFoot.Enable();
   }

   void LateUpdate()
   {
      playerLook.ProcessLook(onFoot.Look.ReadValue<Vector2>());
   }

   void FixedUpdate()
   {
      playerMotor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
   }

   void Update()
   {

   }

    void OnDisable()
    {
        onFoot.Disable();
    }
}
