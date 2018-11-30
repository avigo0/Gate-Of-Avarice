using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    public CharacterController2D controller;
    bool jump = false;
    public float direction = 1;

    //Gets ran every frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        direction = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump")){
            jump = true;
        }
    }


    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, false, jump);
        jump = false;

    }


}
