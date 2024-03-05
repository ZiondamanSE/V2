using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem; 
using UnityEngine;

public class InputManeger : MonoBehaviour
{
    private Movment playerInput;
    public  Movment.OnFootActions onFoot;

    private PMovment Motor;
    private PLook look;

    void Awake()
    {
        playerInput = new Movment();
        onFoot = playerInput.OnFoot;  // Assigning the OnFootActions correctly

        Motor = GetComponent<PMovment>();
        look = GetComponent<PLook>();

        onFoot.Enable();  // Enabling the entire player input system

        onFoot.Jump.performed += ctx => Motor.Jump(); // Jumping

    }

    void FixedUpdate()
    {
        Motor.ProcessMove(onFoot.Movment.ReadValue<Vector2>());
    }
    void LateUpdate()
    {
        if (look != null)
        {
            look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
        }
        else
        {
            Debug.LogWarning("PLook component not found on the GameObject with InputManeger script.");
        }
    }

    private void OnDisable()
    {
        onFoot.Disable();  // Disabling the entire player input system
    }
}