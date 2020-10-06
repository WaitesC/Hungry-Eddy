using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public Animator animator;

    public float runSpeed = 40f;

    float horMove = 0f;

    bool jump = false;

    void Start()
    {
        animator.SetBool("Grounded", true);

    }

    // Update is called once per frame
    void Update()
    {
        horMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horMove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.Play("Eddie_Jump_Normal");
            

        }

        if (Input.GetButtonDown("Tongue"))
        {
            animator.Play("Eddie_Tongue_Normal");
        }
    }

    void FixedUpdate()
    {
        controller.Move(horMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
