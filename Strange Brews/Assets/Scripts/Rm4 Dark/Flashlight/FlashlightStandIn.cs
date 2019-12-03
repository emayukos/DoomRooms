using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightStandIn : Photon.MonoBehaviour
{
    public GameObject personalTextBox;
    public GameObject realFlashlight;
    public PhotonView thisPhotonView;
    GameObject player;
    private bool inRange = false;



    // Update is called once per frame
    void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            personalTextBox.GetComponent<InteractText>().photonView.RPC("DisplayLook", PhotonTargets.All, "A blacklight flashlight was picked up.");
            //activateFL();
            thisPhotonView.RPC("activateFL", PhotonTargets.All);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            player = collision.gameObject;
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            player = null;
            inRange = false;
        }
    }

    [PunRPC]
    private void activateFL()
    {
        realFlashlight.GetComponent<FlashlightFollow>().activateLight(player);
        //realFlashlight.GetComponent<FlashlightFollow>().photonView.RPC("activateLight", PhotonTargets.All, player);
        //Destroy(gameObject);
        PhotonNetwork.Destroy(gameObject);
    }
}
