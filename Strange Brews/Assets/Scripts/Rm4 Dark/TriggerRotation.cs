using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRotation : MonoBehaviour
{
    public PhotonView photonView;
    GameObject personalTextBox;
    private Rigidbody2D rbody;
    private bool rotate = false;
    private float rotateBy;
    private float rotationSpeed = 1.0f; //set to public to manipulate if need be
    private float highBound, lowBound;
    private Quaternion transformRotation;

    void Start()
    {
        personalTextBox = GameObject.Find("Personal Message Text");
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

    private void FixedUpdate()
    {
        if (rotate)
        {
            //rotates object by rotateBy speed and direction within set bounds
            photonView.RPC("rotateWall", PhotonTargets.All);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            rotate = true;
            personalTextBox.GetComponent<InteractText>().photonView.RPC("DisplayLook", PhotonTargets.All, "The joints in the middle seem a little rusty.");
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
        if(collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            rotate = false;
            //transformRotation = transform.rotation;
            //photonView.RPC("syncWalls", PhotonTargets.All, transformRotation);
        }
    }

    [PunRPC]
    public void rotateWall()
    {
        rbody.MoveRotation(Mathf.Clamp(rbody.rotation + rotateBy, lowBound, highBound));
    }

    [PunRPC]
    public void syncWalls(Quaternion t)
    {
        transform.rotation = t;
    }
}
