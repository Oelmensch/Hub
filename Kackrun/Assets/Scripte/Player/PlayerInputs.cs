using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PlayerInputs : MonoBehaviour
{
    [HideInInspector] public float horizontal;
    [HideInInspector] public bool jumpHeld;
    [HideInInspector] public bool jumpPressed;
    [HideInInspector] public bool crouchHeld;
    [HideInInspector] public bool crouchPressed;

    private bool readyToClear;

    void Start()
    {
        
    }

    void Update()
    {
        ClearInput();

        if (GameManager.IsGameOver())
            return;

        ProcessInputs();

        horizontal = Mathf.Clamp(horizontal, -1f, 1f);
    }

    private void FixedUpdate()
    {
        readyToClear = true;
    }

    void ClearInput()
    {
        if (!readyToClear)
            return;

        horizontal      = 0f;
        jumpPressed     = false;
        jumpHeld        = false;
        crouchPressed   = false;
        crouchHeld      = false;
        readyToClear    = false;
    }

    void ProcessInputs()
    {
        horizontal += Input.GetAxis("Horizontal");

        jumpPressed = jumpPressed || Input.GetButtonDown("Jump");
        jumpHeld = jumpHeld || Input.GetButton("Jump");

        crouchPressed = crouchPressed || Input.GetButtonDown("Crouch");
        crouchHeld = crouchHeld || Input.GetButton("Crouch");
    }
}
