using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globe : MonoBehaviour
{

    public Sprite globeClosed;
    public Sprite globeOpen;
    private bool inRange;
    private bool isOpen;
    public GameObject key;


    // Start is called before the first frame update
    void Start()
    {
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E)) // make icon that says "press E" to open
        {
            //for single player testing
            if (isOpen)
            {
                openGlobe();
            }
            else
            {
                closeGlobe();
            }

            // for photon
            //if (isOn)
            //{
            //    this.photonView.RPC("openGlobe", PhotonTargets.All);
            //}
            //else
            //{
            //    this.photonView.RPC("closeGlobe", PhotonTargets.All);

            //}
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // for single player testing
        if (col.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
        else
        {
            Debug.Log("OnTriggerEnter comaring tag isn't player");
        }

        // for photon testing
        //inRange |= col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        // For single player testing
        if (col.gameObject.CompareTag("Player"))
        {
            inRange = false;
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

    //[PunRPC]
    void openGlobe()
    {
        //Open Globe
        GetComponent<SpriteRenderer>().sprite = globeOpen;
        isOpen = true;
        key.SetActive(true);
    }


    //[PunRPC]
    void closeGlobe()
    {
        //Close Globe
        GetComponent<SpriteRenderer>().sprite = globeClosed;
        isOpen = false;
        key.SetActive(false);

    }

}
