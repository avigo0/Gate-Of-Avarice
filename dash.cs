using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour {
    private Rigidbody2D rb;
    public float dashSpeedG = 5; // ground
    public float dashSpeedA = 65; // air
    [SerializeField]
    [Range(-1f, 1f)]
    private float dashTime = 0f;
    [Range(0f, 20f)]
    public float distance = 0.9f;
    [Range(0f, 20f)]
    public float sideDistance = 0.9f;
    public float startDashTime = .15f;
    private float direction;
    bool isDashing = false;
    float tempGrav;
    private int counter;
    [SerializeField]
    private int dashCounter = 5;
    //bool isInAIr;
    // Use this for initialization
    // Use this for initialization
    void Start()
    {
        isDashing = false;
        rb = GetComponent<Rigidbody2D>();
        counter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = Input.GetAxisRaw("Horizontal");
        checkDashRequest();
    }

    bool isInAir()
    {
        try
        {
            // Debug.Log("checking if in air");
            RaycastHit2D resultDOWN = Physics2D.Raycast(rb.position, Vector2.down);
            RaycastHit2D resultRIGHTDiag = Physics2D.Raycast(rb.position, (Vector2.down + Vector2.right));
            RaycastHit2D resultLEFTDiag = Physics2D.Raycast(rb.position, (Vector2.down + Vector2.left));

            return ((resultDOWN.distance > distance) || ((resultRIGHTDiag.distance > sideDistance)) || ((resultLEFTDiag.distance > sideDistance)));

        }
        catch (System.NullReferenceException error)
        {
            Debug.Log(error);
            return false;
        }

    }
    // bool onGround;
    [Range(-1f, 1f)]
    public float dist = .28f;
    [Range(-1f, 1f)]
    public float sideDist = 0.3975f;
    bool isGrounded()
    {
        //Debug.Log("checking if in air");
        try
        {
            RaycastHit2D resultDOWN = Physics2D.Raycast(rb.position, Vector2.down);
            RaycastHit2D resultRIGHTDiag = Physics2D.Raycast(rb.position, (Vector2.down + Vector2.right));
            RaycastHit2D resultLEFTDiag = Physics2D.Raycast(rb.position, (Vector2.down + Vector2.left));

            return ((resultDOWN.collider.tag == "Floor" || resultRIGHTDiag.collider.tag == "Floor" || resultLEFTDiag.collider.tag == "Floor") && ((resultDOWN.distance < dist) ||
               ((resultRIGHTDiag.distance > 0) && (resultRIGHTDiag.distance < sideDist) || ((resultLEFTDiag.distance > 0) && (resultLEFTDiag.distance < sideDist)))));
        }

        catch (System.NullReferenceException error)
        {
            Debug.Log(error);
            return false;
        }
    }
    

    void Dash() //Direction?  if button left then direction is negative one ect.
    {


        if (!isDashing) //&&& prepared to dash
        {
            tempGrav = rb.gravityScale;
            if (isInAir()) //and dashing? 
            {
                if (counter < 1)
                {
                    rb.AddForce(Vector2.right * dashSpeedA * direction + new Vector2(2f, 2f), ForceMode2D.Impulse);
                    counter++; // for dash counter
                    Debug.Log("AIR DASHING COUNTER: " + counter);
                }

            }
            else if (isGrounded())
            {
                // rb.AddForce(Vector2.right * dashSpeedG * direction, ForceMode2D.Impulse);
                // isDashing = true;
                counter = 0;
                do
                {
                    Debug.Log("dash time: " + dashTime);
                    rb.AddForce(Vector2.right * dashSpeedG * direction, ForceMode2D.Impulse);
                    if (dashTime <= 0f)
                    { // we must be done dashing
                        direction = 0; // we want to stop dashing here
                        isDashing = false;
                        dashTime = startDashTime;
                        rb.gravityScale = tempGrav;
                        Debug.Log("dash COMPLETE: " + !isDashing);
                    }
                    else
                    {
                        isDashing = true;
                        counter++;
                        //Debug.Log("we must be dashing");
                        dashTime -= Time.fixedDeltaTime; //MAYBe
                    }
                } while (isDashing);
               

                //rb.transform.Translate(Vector2.right * dashSpeed * direction);// Teleport LOL
            }
            else
            {
                isDashing = false;
            }
            //Debug.Log("DASHING: " + isDashing + " Dash Time : " + dashTime);
        }

    }
    //+++++=============DASH MECH=============++\\\ (MINORBUGS DOWN HERE)

    void checkDashRequest()
    {
        
        if (isGrounded())
            counter = 0;
        if ((dashCounter > 0) && (Input.GetButtonDown("Dash") && (direction != 0)))
        {
            Dash();
            dashCounter--;
            Debug.Log(dashCounter);
        }



    }

    bool rightButtonDown()
    {
        return (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0);
    }

    bool leftButtonDown()
    {
        return (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0);
    }

    void setDashcount(int dashCount)
    {
        this.dashCounter = dashCount;
    }
}


