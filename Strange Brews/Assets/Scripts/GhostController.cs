using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
	public PhotonView photoView;
    // movement variable
    public float moveSpeed = 4f;

    // Animation Variables
    Animator thisAnim;
    float lastX, lastY;

    Rigidbody2D rbody;

    private void Start()
    {
        thisAnim = GetComponent<Animator>();
        rbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();

        //stops rotation after hitting a collider
        rbody.MoveRotation(0.0f);
    }

    void Move()
    {
        Vector3 rightMovement = Vector3.right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = Vector3.up * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.position += rightMovement;
        transform.position += upMovement;

        //stops drifting with transform movement after hitting a collider
        rbody.velocity = new Vector2(0, 0);
        rbody.velocity = new Vector2(moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"));

        UpdateAnimation(heading);
    }

    void UpdateAnimation(Vector3 dir)
    {
        if(dir.x == 0f && dir.y == 0f)
        {
            thisAnim.SetFloat("Last_DirectionX", lastX);
            thisAnim.SetFloat("Last_DirectionY", lastY);
            thisAnim.SetBool("Movement", false);

        }
        else
        {
            lastX = dir.x;
            lastY = dir.y;
            thisAnim.SetBool("Movement", true);

        }

        thisAnim.SetFloat("DirX", dir.x);
        thisAnim.SetFloat("DirY", dir.y);
    }
    
    
    
    
    
}
/**
    //  What is the maximum speed we want the Ghost to walk at
    private float maxSpeed = 8f;

    // Start facing the right
    private bool facingRight = true;

    // This will be a reference to the RigidBody2D
    // component in the Player object
    private Rigidbody2D rb;

    // This is a reference to the Animator component
    private Animator anim;

    // We initialize our two references in the Start method
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the extent to which the player is currently pressing left or right
        float h = Input.GetAxis("Horizontal");
        // Get the extent to which the player is currently pressing up or down
        float v = Input.GetAxis("Vertical");

        // Move the RigidBody2D (which holds the player sprite)
        // on the x axis based on the stae of input and the maxSpeed variable
        rb.velocity = new Vector3(h * maxSpeed, v * maxSpeed, rb.velocity.y);

        // Pass in the current velocity of the RigidBody2D
        // The speed parameter of the Animator now knows
        // how fast the player is moving and responds accordingly
        if (Mathf.Abs(h) > 0)
        {
            anim.SetFloat("Speed", Mathf.Abs(8f));
        } else if (v > 0)
        {
            anim.SetFloat("Up_Speed", Mathf.Abs(8f));
        }
            else if (v < 0)
        {
            anim.SetFloat("Down_Speed", Mathf.Abs(8f));
        }
            else
        {
            anim.SetFloat("Speed", Mathf.Abs(0f));
            anim.SetFloat("Up_Speed", 0f);
            anim.SetFloat("Down_Speed", 0f);
        }
        

        // Check which way the player is facing 
        // and call reverseImage if neccessary
        if (h > 0 && !facingRight)
            reverseImage();
        else if (h < 0 && facingRight)
            reverseImage();
    }

    void reverseImage()
    {
        // Switch the value of the Boolean
        facingRight = !facingRight;

        // Get and store the local scale of the RigidBody2D
        Vector2 theScale = rb.transform.localScale;

        // Flip it around the other way
        theScale.x *= -1;
        rb.transform.localScale = theScale;
    }
    **/
