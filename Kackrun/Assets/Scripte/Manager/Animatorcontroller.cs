using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatorcontroller : MonoBehaviour
{
    PlayerController movement;
    Rigidbody2D rigidBody;
    PlayerInputs input;
    Animator anim;

    private int hangingParamID;
    private int groundParamID;
    private int crouchParamID;
    private int speedParamID;
    private int fallParamID;



    void Start()
    {
        hangingParamID = Animator.StringToHash("isHanging");
        groundParamID = Animator.StringToHash("isOnGround");
        crouchParamID = Animator.StringToHash("isCrouching");
        speedParamID = Animator.StringToHash("speed");
        fallParamID = Animator.StringToHash("verticalVelocity");

        Transform parent = transform.parent;

        movement = parent.GetComponent<PlayerController>();
        rigidBody = parent.GetComponent<Rigidbody2D>();
        input = parent.GetComponent<PlayerInputs>();
        anim = GetComponent<Animator>();

        if (movement == null || rigidBody == null || input == null || anim == null)
        {
            Debug.LogError("A needed component is missing from the Player");
            Destroy(this);
        }
    }

    void Update()
    {
        anim.SetBool(hangingParamID, movement.isHanging);
        anim.SetBool(groundParamID, movement.isOnGround);
        anim.SetBool(crouchParamID, movement.isCrouching);
        anim.SetFloat(fallParamID, rigidBody.velocity.y);

        anim.SetFloat(speedParamID, Mathf.Abs(input.horizontal));
    }
    public void StepAudio()
    {
        AudioManager.PlayFootstepAudio();
    }

    public void CrouchStepAudio()
    {
        AudioManager.PlayCrouchFootstepAudio();

    }

}
