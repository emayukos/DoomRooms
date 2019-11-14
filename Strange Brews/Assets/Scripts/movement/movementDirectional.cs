using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementDirectional : MonoBehaviour
{
    public int walkVelocity = 7;
    public int runVelocity = 13;
    private float sightRotation = 0.0f;

    private Rigidbody2D rbody;

    // Start is called before the first frame update 
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //keep player facing the direction they're moving in
        //rather than spinning upon collision contact due to physics
        sightRotate(v, h);
        rbody.MoveRotation(sightRotation);

        if (Input.GetKey(KeyCode.R))
        {
            //running speed
            rbody.velocity = new Vector2(runVelocity * h, runVelocity * v);
        }
        else
        {
            //regular walking speed
            rbody.velocity = new Vector2(walkVelocity * h, walkVelocity * v);
        }

    }


    //aligns degree of rotation with which directional keys are held down
    private void sightRotate(float v, float h)
    {
        if (v == 0)
        {
            if (h < 0)
            {
                //left
                sightRotation = 180;
            }
            if (h > 0)
            {
                //right
                sightRotation = 0;
            }
        }
        else if (h == 0)
        {
            if (v > 0)
            {
                //up
                sightRotation = 90;
            }
            if (v < 0)
            {
                //down
                sightRotation = -90;
            }
        }
        else
        {
            if (v > 0)
            {
                //diag up
                if (h < 0)
                {
                    //diag up left
                    sightRotation = 135;
                }
                if (h > 0)
                {
                    //diag up right
                    sightRotation = 45;
                }
            }
            if (v < 0)
            {
                //diag down
                if (h < 0)
                {
                    //diag down left
                    sightRotation = -135;
                }
                if (h > 0)
                {
                    //diag down right
                    sightRotation = -45;
                }
            }
        }
    }
}


