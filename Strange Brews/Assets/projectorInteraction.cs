using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectorInteraction : Photon.MonoBehaviour
{
    public Sprite projOff;
    public Sprite projOn;
    private bool inRange = false;
    public GameObject projectorScreen;
    private bool isOn = false;


    // Start is called before the first frame update
    void Start()
    {
        projectorScreen.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E)) // make icon that says "press E" to open
        {
            if (isOn)
            {
                this.photonView.RPC("TurnOffProjector", PhotonTargets.All);
            }
            else
            {
                this.photonView.RPC("TurnOnProjector", PhotonTargets.All);

            }
        }


    }

    private void OnTriggerEnter(Collider2D col)
    {
        inRange |= col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine)
        {
            inRange = false;
            this.photonView.RPC("CloseBox", PhotonTargets.All);
        }
    }

    [PunRPC]
    void TurnOnProjector()
    {
        //Turn on projector
        GetComponent<SpriteRenderer>().sprite = projOn;
        isOn = true;
        projectorScreen.SetActive(true);

    }

    [PunRPC]
    void TurnOffProjector()
    {
        //Turn off projector
        if (isOn)
        {
            //Turn projector off if projector if on and player presses "e" again
            GetComponent<SpriteRenderer>().sprite = projOff;
            projectorScreen.SetActive(false);
            isOn = false;
        }
    }

}
