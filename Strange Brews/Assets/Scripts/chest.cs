using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// emma
public class chest : MonoBehaviour
{
    public GameObject openedChest, closedChest;

    private PhotonView photonView;


    private AudioSource source;
    public AudioClip openChestSound;

    private void Start()
    {
        // hide the opened chest
        openedChest.SetActive(false);

        source = GetComponent<AudioSource>();
        photonView = GetComponent<PhotonView>();
    }

    // this is a wrapper function for the RPC
    public void openChest()
    {
        photonView.RPC("openChestRPC", PhotonTargets.All);
    }

    // an RPC so it happens on both
    [PunRPC]
    public void openChestRPC()
    {
        // hide the closed chest
        closedChest.SetActive(false);
        // show the open chest
        openedChest.SetActive(true);
        // this will show the ingredients hidden inside bc they are
        // children of the opened chest

        source.PlayOneShot(openChestSound);
    }
}
