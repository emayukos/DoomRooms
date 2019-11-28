using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightStandIn : Photon.MonoBehaviour
{
    public GameObject realFlashlight;
    GameObject player;
    private bool inRange = false;



    // Update is called once per frame
    void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.E))
        {
            activateFL();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player = collision.gameObject;
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = null;
            inRange = false;
        }
    }

    private void activateFL()
    {
        realFlashlight.GetComponent<FlashlightFollow>().activateLight(player);
        //realFlashlight.GetComponent<FlashlightFollow>().photonView.RPC("activateLight", PhotonTargets.All, player);
        Destroy(gameObject);
        //PhotonNetwork.Destroy(gameObject);
    }
}
