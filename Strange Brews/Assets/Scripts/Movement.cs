using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Photon.MonoBehaviour
{
    public bool devTesting;

    /*
     * this takes all the values (transform, position, etc.)
     * and passes it across the network
     */
    public PhotonView photonView;

    private Vector3 selfPosition;

    private Vector3 selfScale;

    private float velocity;

    private float characterscale;

    private Rigidbody2D rbody;


    private Vector2 position;

    private float initial_y;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        velocity = 5.0f;
        position = rbody.position;
        initial_y = position.y;

    }

    // FixedUpdate is called at a fixed rate, while Update is simply called for every rendered frame
    // FixedUpdate should be used to write the code related to the physics simulation (e.g. applying force, setting velocity and so on)
    void FixedUpdate()
    {
        
        if (! devTesting)
        {
            /* this makes sure it only moves the one player */
            if (photonView.isMine)
            {
                moveCharacter();
            }
            else
            {
                smoothNetMovement();
            }
        }
        else
        {
            moveCharacter();
        }
        
        
    }

    private void moveCharacter()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rbody.velocity = new Vector2(velocity * h, velocity * v);

        characterscale = (transform.position.y - (transform.position.y - initial_y) * 0.5f) / initial_y;

        transform.localScale = new Vector3(characterscale, characterscale, characterscale);
    }

    private void smoothNetMovement()
    {
        transform.position = Vector3.Lerp(transform.position, selfPosition, Time.deltaTime * 8);
        transform.localScale = Vector3.Lerp(transform.localScale, selfScale, Time.deltaTime * 8);
    }




    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // if it is the local player it streams the positions and other things
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.localScale);
        }
        else
        {
            selfPosition = (Vector3)stream.ReceiveNext();
            selfScale = (Vector3)stream.ReceiveNext();

        }
    }


}
