using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovement : MonoBehaviour
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



        sightRotate(v, h);
        rbody.MoveRotation(sightRotation);

        if (Input.GetKey(KeyCode.R))
        {
            rbody.velocity = new Vector2(runVelocity * h, runVelocity * v);
        }
        else
        {
            rbody.velocity = new Vector2(walkVelocity * h, walkVelocity * v);
        }

    }


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


