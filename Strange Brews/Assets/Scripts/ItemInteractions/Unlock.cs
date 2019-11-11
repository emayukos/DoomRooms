using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    public PhotonView photonView;
    GameObject inventory;
    GameObject interactionTextBox;
    GameObject actionTextBox;

    private string lockedThingFound = null;
    private string lockedThingKey = null;
    private string unlockDescription = null;
    private bool unlock = false;


    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory");
        interactionTextBox = GameObject.Find("Interaction Text");
        actionTextBox = GameObject.Find("Action Log Text");
    }

    // Update is called once per frame
    void Update()
    {
        if (lockedThingFound != null)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                //unlock
                unlock = inventory.GetComponent<Inventory>().searchItem(lockedThingKey);

                
                if(unlock == true)
                {
                    //Destroy(gameObject);
                    actionTextBox.GetComponent<InteractText>().photonView.RPC("AddText", PhotonTargets.All, unlockDescription);
                    this.photonView.RPC("unlockThing", PhotonTargets.All);
                }
                else
                {
                    Debug.Log("This needs a key.");
                    interactionTextBox.GetComponent<InteractText>().DisplayLook("This needs a key.");
                }
                
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col)   //col -> other thing was collided with, if attached to coin -> col = player
    {
        if (col.gameObject.CompareTag("Player"))
        {
            lockedThingKey = GetComponent<AssignedKey>().getKeyName();
            unlockDescription = GetComponent<AssignedKey>().getUnlockDescription();
            lockedThingFound = GetComponent<Interactable>().getLookDescription();
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        lockedThingKey = null;
        lockedThingFound = null;
        unlockDescription = null;
    }

    [PunRPC]
    private void unlockThing()
    {
        PhotonNetwork.Destroy(gameObject);
    }

}
