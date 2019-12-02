using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nightStandB : MonoBehaviour
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
        GetComponent<Interactable>().setLookDescription("An unlocked side table.");
        position = openSprite.transform.position;
        openSprite.transform.position = closedPos.transform.position;
    }

    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {

            if (inRange)
            {
                //record unlocking action in 2-player log, then perform unlocking action
                //networkTextBox.GetComponent<ShowNewMessage>().setHaveNewMessage();
                networkTextBox.GetComponent<InteractText>().photonView.RPC("DisplayLook", PhotonTargets.All, "The night stand was opened.");
                this.photonView.RPC("openNightStand", PhotonTargets.All);
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
    private void openNightStand()
    {
        //itemInside.SetActive(true);
        //do what's needed to the lockedThing
        openSprite.transform.position = position;
        PhotonNetwork.Destroy(gameObject);

    }
}
