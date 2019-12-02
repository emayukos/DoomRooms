using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectorInteraction : MonoBehaviour
{
    public Sprite projOff;
    public Sprite projOn;
    private bool inRange;
    public GameObject projectorScreen;
    private bool isOn = false;
    private AudioSource projectorOnAudio;
    GameObject networkTextBox;



    // Start is called before the first frame update
    void Start()
    {
        projectorScreen.SetActive(false);
        projectorOnAudio = GetComponent<AudioSource>();
        networkTextBox = GameObject.Find("Network Message Text");
    }

    // Update is called once per frame
    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E)) // make icon that says "press E" to open
        {
            //for single player testing
            if (isOn)
            {
                TurnOffProjector();
                networkTextBox.GetComponent<InteractText>().photonView.RPC(
                    "DisplayLook", PhotonTargets.All, "The projector has been turned off!");
            }
            else
            {
                TurnOnProjector();
                networkTextBox.GetComponent<InteractText>().photonView.RPC(
                    "DisplayLook", PhotonTargets.All, "The projector has been turned on!");
            }

            // for photon
            //if (isOn)
            //{
            //    this.photonView.RPC("TurnOffProjector", PhotonTargets.All);
            //}
            //else
            //{
            //    this.photonView.RPC("TurnOnProjector", PhotonTargets.All);

            //}
        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // for single player testing
        if (col.gameObject.CompareTag("Player") )
        {
            if (col.GetComponent<PhotonView>().isMine)
            {
                inRange = true;
            }
            
        } else
        {
            Debug.Log("OnTriggerEnter comaring tag isn't player");
        }

        // for photon testing
        //inRange |= col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        // For single player testing
        if(col.gameObject.CompareTag("Player"))
        {
            if (col.GetComponent<PhotonView>().isMine)
            {
                inRange = false;
            }
                
        }
        else
        {
            Debug.Log("OnTriggerExit comaring tag isn't player");
        }

        //// for photon testing
        //if (col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine)
        //{
        //    inRange = false;
        //    this.photonView.RPC("CloseBox", PhotonTargets.All);
        //}
    }

    // for single player testing
    [PunRPC]
    void TurnOnProjector()
    {
        //Turn on projector
        GetComponent<SpriteRenderer>().sprite = projOn;
        isOn = true;
        projectorScreen.SetActive(true);
        projectorOnAudio.Play();

    }
    // for photon
    //[PunRPC]
    //void TurnOnProjector()
    //{
    //    //Turn on projector
    //    GetComponent<SpriteRenderer>().sprite = projOn;
    //    isOn = true;
    //    projectorScreen.SetActive(true);

    //}
    // for single player testing
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
            projectorOnAudio.Pause();
        }
    }
    // for photon
    //[PunRPC]
    //void TurnOffProjector()
    //{
    //    //Turn off projector
    //    if (isOn)
    //    {
    //        //Turn projector off if projector if on and player presses "e" again
    //        GetComponent<SpriteRenderer>().sprite = projOff;
    //        projectorScreen.SetActive(false);
    //        isOn = false;
    //    }
    //}

}
