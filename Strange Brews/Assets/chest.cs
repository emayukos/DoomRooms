using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public GameObject openedChest, closedChest;

    private PhotonView photonView;


    private AudioSource source;
    public AudioClip openChestSound;

    private void Start()
    {
        openedChest.SetActive(false);

        source = GetComponent<AudioSource>();
        photonView = GetComponent<PhotonView>();
    }

    public void openChest()
    {
        photonView.RPC("openChestRPC", PhotonTargets.All);
    }

    [PunRPC]
    public void openChestRPC()
    {
        closedChest.SetActive(false);
        openedChest.SetActive(true);

        source.PlayOneShot(openChestSound);
    }
}
