﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    /*
    public enum MOVEMENT_TYPE { UNITS, FORCE, VEL };

    public float delta;
    // public means another script can access it
    // in unity everything that is public has a little field in the inspector
    public float movement_force;

    public MOVEMENT_TYPE movement_type;

    */
    private float velocity;

    private float characterscale;

    private Rigidbody2D rbody;

    private bool moving = true;

    private Vector2 position;
    private float initial_y;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        // getting the component of the object we are attatched too
        // can use this variable to access this object
        // this is the component it is attached to
        // any object you attatch this script to has to have a Rigidbody2D
        velocity = 5.0f;
        position = rbody.position;
        initial_y = position.y;

    }

    // FixedUpdate is called at a fixed rate, while Update is simply called for every rendered frame
    // FixedUpdate should be used to write the code related to the physics simulation (e.g. applying force, setting velocity and so on)
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        /* how does input work in unity
         * axis, buttons, keys
         * this one is happening everysingle update
         * this is going to check every frame if the key is being pressed
         * it is best to put them into a variable so that you can change the keys quickly
         * the horizontal and veritcal are the axis
         * horizontal is automatically mapped to a and d and the arrow keys
         * vertical is automatically mapped to w and s and the arrown key
         * if you are pressing d then it will slowly increment up to one and when it is let go
         * it slowly goes back to 0
         * just says if they pressed the button
         *
         * edit / project settings / input / axes / horizontal
         *      here you can change the name or the keys without changing the code
         *      don't really touch the settings unless you know what you are doing
         */
        rbody.velocity = new Vector2(velocity * h, velocity * v);
        /* this one will override any other physics interacting with it
         */
        characterscale = (transform.position.y - (transform.position.y - initial_y) * 0.5f) / initial_y;
        
        transform.localScale = new Vector3(characterscale, characterscale, characterscale);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moving = false;
    }
    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        string hitObject = collisionInfo.collider.tag;
        moving = false;
    }

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        Debug.Log("Exit !!!");
        moving = true;
    }

}
