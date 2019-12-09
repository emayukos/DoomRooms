using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dresserA : MonoBehaviour
{
    public PhotonView photonView;
    public GameObject networkTextBox;
    public GameObject openSprite;
    public GameObject closedPos;
    private Vector3 position;
    private bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        //All Interactable objects
        GetComponent<Interactable>().setLookDescription("An unlocked dresser.");
        position = openSprite.transform.position;
        openSprite.transform.position = closedPos.transform.position;
    }

    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {

            if (inRange)
            {
                //open dresser and tell player they did it
                networkTextBox.GetComponent<InteractText>().photonView.RPC("DisplayLook", PhotonTargets.All, "The dresser A was opened.");
                this.photonView.RPC("openDresser", PhotonTargets.All);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)   //col -> other thing was collided with, if attached to coin -> col = player
    {
        if (col.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    [PunRPC]
    private void openDresser()
    {
        //move open dresser with clue to dresser position, destroy closed dresser
        openSprite.transform.position = position;
        PhotonNetwork.Destroy(gameObject);

    }

}
