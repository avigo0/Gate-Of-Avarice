using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* Dash works by applying a force onto the player's rigidbody.
*/
public class Dash : MonoBehaviour {
    Rigidbody2D rb;                 //Used to apply the force to create dash
    public float dashSpeed = 80f;   //Amount of force to be applied to dash
    public PlayerMovement movement; //Used to find out what direction player is 
                                    //moving
    public ParticleSystem dashTrail; //Dash Particle Effects
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        //Checks if the user want to dash and what direction player is moving
        //Makes it so player cannot dash twice in the air
        if (Input.GetButtonDown("Dash")){
            if (movement.direction < 0)
            {
                rb.AddForce(Vector2.left * dashSpeed, ForceMode2D.Impulse);
                dashTrail.Emit(10);
            }
            else if (movement.direction > 0)
            {
                rb.AddForce(Vector2.right * dashSpeed, ForceMode2D.Impulse);
                dashTrail.Emit(10);
            }
            
        }
	}

}
