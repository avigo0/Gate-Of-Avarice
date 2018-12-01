using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Handles the player walking and the speed they want to walk. Uses the character
 * controllerScript to handle the physics behind it. This script just gets userInput
 * which represents which direction they want to walk.
 */
public class PlayerMovement : MonoBehaviour {
    float horizontalMove = 0f;  //Input to tell the controller which direction and
                                //speed to walk
    public float runSpeed = 40f;//Speed of the walk
    public CharacterController2D controller;//controller that handles physics
    public float direction = 1; //Used for dash

    void Update()
    {
        //Initialize horizontalMove to tell controller where to move and how fast
        //Direction will be 1 if moving right and -1 if moving left
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        direction = Input.GetAxisRaw("Horizontal");
    }

    //Good practice to make player movement on fixed update
    //Calls character controller method to move player with the given speed
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, false, false);
    }


}
