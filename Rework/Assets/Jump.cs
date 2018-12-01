using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Jump works by applying a force underneath the player object's rigidbody2D.
 */
public class Jump : MonoBehaviour {
    public float jumpForce = 10f; //jumping force
    public float wallJumpForce = 15f; //wall jumping force
    Rigidbody2D rb;               //physics component to apply jump
    public int jumping = 0;  //0 if cant jump, 1 if floor, 2 if wall

    void Start()
    {
        //Reference to rigidbody component
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        //Applies a force up to simulate jumping off the floor
        if (jumping == 1 && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumping = 0;
        }
        //Applies a force to either up and to the left or right to simulate a wall jump
        else if (jumping == 2 && Input.GetButtonDown("Jump"))
        {
            if (Input.GetKey("d"))
            { //if you press jump and hold d, apply a force to simulate a jump off the walla
                Vector3 upLeft = Quaternion.AngleAxis(135, Vector3.forward) * Vector3.right * wallJumpForce;
                rb.AddForce(upLeft, ForceMode2D.Impulse);
                jumping = 0;
            }
            else if (Input.GetKey("a"))
            { //if you press jump and hold a, apply a force to simulate a jump off the wall
                Vector3 upRight = Quaternion.AngleAxis(45, Vector3.forward) * Vector3.right * wallJumpForce;
                rb.AddForce(upRight, ForceMode2D.Impulse);
                jumping = 0;
            }
        }
	}

    //When the object hits the floor, than the player can jump again
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Floor"){
            jumping = 1;
        }
        if(other.gameObject.tag == "Wall"){
            jumping = 2;
        }
    
    }
}
