using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundSafe : MonoBehaviour
{
    //probably over-complicated hidden safe reveal
    public GameObject safe;
    public PhotonView photonview;
    public PhotonView thisPhotonView;
    public SpriteRenderer foundSafeSprite;
    public GameObject networkTextBox;

    private bool inRange = false;
    private Color originalColour;


    void Start()
    {
        //safe.SetActive(false);
        originalColour = foundSafeSprite.color;
        foundSafeSprite.color = Color.clear;
    }


    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            networkTextBox.GetComponent<InteractText>().photonView.RPC("DisplayLook", PhotonTargets.All, "Pushing a brick revealed a hidden safe.");
            this.photonview.RPC("activate", PhotonTargets.All);
            //this script is no longer needed, so deactivate it
            thisPhotonView.RPC("deactivateThis", PhotonTargets.All);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            inRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            inRange = false;
        }
    }

    [PunRPC]
    public void deactivateThis()
    {
        //grey panel showing where hidden safe is, once it's found
        foundSafeSprite.color = originalColour;
        gameObject.SetActive(false);
    }

}
