using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {
    public PlayerMovement movement;
    public float posX;
    public float poxY;
    Rigidbody2D rb;
    public float dashSpeed = 80f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Dash")){
            if (movement.direction < 0)
            {
                rb.AddForce(Vector2.left * dashSpeed, ForceMode2D.Impulse);
            }
            else if (movement.direction > 0)
            {
                rb.AddForce(Vector2.right * dashSpeed, ForceMode2D.Impulse);
            }
            
        }
	}
}
