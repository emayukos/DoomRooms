using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRotation : MonoBehaviour
{
    public PhotonView photonView;
    private Rigidbody2D rbody;
    private bool rotate = false;
    private float rotateBy;
    private float rotationSpeed = 1.0f; //set to public to manipulate if need be
    private float highBound, lowBound;


    void Start()
    {
        rbody = transform.parent.gameObject.GetComponent<Rigidbody2D>();

        //sets the limits of how far the turntable can rotate in either direction
        if (rbody.gameObject.name == "Mid Spinner wall")
        {
            highBound = 0.0f;
            lowBound = -90.0f;
        }

        if (rbody.gameObject.name == "End Spinner wall")
        {
            highBound = 60.0f;
            lowBound = -60.0f;
        }
    }

    private void Update()
    {
        if (rotate)
        {
            //rotates object by rotateBy speed and direction within set bounds
            photonView.RPC("rotateWall", PhotonTargets.All);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rotate = true;
        }

        if (gameObject.tag == "clockwise spin")
        {
            //change rotation to clockwise spin
            rotateBy = rotationSpeed * -1.0f;
        }
        if (gameObject.tag == "c.clockwise spin")
        {
            //change rotation to counter-clockwise spin
            rotateBy = rotationSpeed * 1.0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        rotate = false;
    }

    [PunRPC]
    public void rotateWall()
    {
        rbody.MoveRotation(Mathf.Clamp(rbody.rotation + rotateBy, lowBound, highBound));
    }
}
