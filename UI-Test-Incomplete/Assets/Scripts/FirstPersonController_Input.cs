using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(FirstPersonController))]
public class FirstPersonController_Input : MonoBehaviour
{
    private InputActions inputActions;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    FirstPersonController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<FirstPersonController>();

        inputActions = new InputActions();

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    void OnDisable()
    {
        inputActions.Disable();
    }
void Update()
    {
        moveInput = inputActions.Player.Move.ReadValue<Vector2>();
        mouseInput = inputActions.Player.Look.ReadValue<Vector2>();

    }
    private void FixedUpdate()
    {
        controller.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), Time.fixedDeltaTime);
    }
    private void LateUpdate()
    {
        controller.Look(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));
    }
}
