﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public enum MOVEMENT_TYPE { UNITS, FORCE, VEL };

    public float delta;
    // public means another script can access it
    // in unity everything that is public has a little field in the inspector
    public float movement_force;
    public float velocity;

    public float characterscale = 1.0f;

    private Rigidbody2D rbody;

    public MOVEMENT_TYPE movement_type;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        // getting the component of the object we are attatched too
        // can use this variable to access this object
        // this is the component it is attached to
        // any object you attatch this script to has to have a Rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        // How to access the position of the object
        // an array of two elements Vector2
        Vector2 pos = transform.position;
        // every object has a transform so this is a shortcut
        // this is how you access the position of the current object


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


        // How to move...
        switch (movement_type)
        {
            // you can choose the movement type in unity with a drop down window
            // are these built in?
            case MOVEMENT_TYPE.UNITS:
                // this is how you move it by units
                // want to overwrite the position of the object
                //transform.position = new Vector2(pos.x + delta, pos.y + delta); // this is moving constantly
                /* this one will move it by delta
                 * the delta can be changed in unity in the inspector window, default 0
                 * this is for when you want something to move one unit at a time
                 * easier to send a message to a server to use this one because it just says move this many units
                 * for top down games
                 */
                transform.position = new Vector2(pos.x + h * delta, pos.y + v * delta);
                // this moves the position when the key is pressed

                if (v > 0 || v < 0)
                {
                    characterscale = characterscale - v / 100;
                    transform.localScale = new Vector3(characterscale, characterscale, characterscale);
                }


                break;
            case MOVEMENT_TYPE.FORCE:
                // how do forces work?
                rbody.AddForce(new Vector2(movement_force * h, movement_force * v));
                // happening every frame
                // every frame your adding force which will change the velocity
                /* this one will be a non linear build up of speeding out until the speed you want
                 * can exponentially increase it
                 * it won't just go from stationary to super fast
                 * if you add a force and something hits it then it flies backwards
                 * this one is good for platformers
                 */
                break;
            case MOVEMENT_TYPE.VEL:
                rbody.velocity = new Vector2(velocity * h, velocity * v);
                /* this one will override any other physics interacting with it
                 */
                if (v > 0 || v < 0)
                {
                    characterscale = characterscale - v / 50;
                    transform.localScale = new Vector3(characterscale, characterscale, characterscale);
                }

                break;
        }
    }
}
