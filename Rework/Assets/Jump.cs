using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Jump works by applying a force underneath the player object's rigidbody2D.
 */
public class Jump : MonoBehaviour {
    public float jumpForce = 10f; //jumping force
    Rigidbody2D rb;               //physics component to apply jump
    public bool jumping = false;  //true if the person is jumping

    void Start()
    {
        //Reference to rigidbody component
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        //Applies a force up to simulate jumping
        if(jumping == false && Input.GetButtonDown("Jump")){
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumping = true;
        }
	}

    //When the object hits the floor, than the player can jump again
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Floor"){
            jumping = false;
        }
    
    }
}
