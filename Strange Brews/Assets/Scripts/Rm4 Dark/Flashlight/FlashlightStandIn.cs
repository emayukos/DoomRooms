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


    void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!player.GetComponent<FlashlightActivate>().haveAFlashlight())
            {
                personalTextBox.GetComponent<InteractText>().photonView.RPC("DisplayLook", PhotonTargets.All, "A blacklight flashlight was picked up.");
                thisPhotonView.RPC("activateFL", PhotonTargets.All);
            }
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
        player.GetComponent<FlashlightActivate>().photonView.RPC("activateFlashlight", PhotonTargets.All);
        // Below commented script is for when flashlight is not attached to player
        // doesn't work for photon, gameObjects can't be passed through RPCs
        //realFlashlight.GetComponent<FlashlightFollow>().activateLight(player);
        //realFlashlight.GetComponent<FlashlightFollow>().photonView.RPC("activateLight", PhotonTargets.All, player);
        thisPhotonView.RPC("delete", PhotonTargets.All);
    }

    [PunRPC]
    private void delete()
    {
        Destroy(gameObject);
    }
}
