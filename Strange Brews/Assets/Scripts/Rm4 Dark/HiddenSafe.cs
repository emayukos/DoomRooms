using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSafe : MonoBehaviour
{
    [SerializeField]
    GameObject codePanel, foundSafe, inventory, safeContents;
    public GameObject networkTextBox;

    private string itemName;
    private bool isActive = true;
    

    public bool isSafeOpened = false; // should not initially be open
    private bool UIopen = false;
    private bool inRange = false;

    public AudioClip safeopening;
    private AudioSource source;


    void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    void Start()
    {
        codePanel.SetActive(false);
        itemName = safeContents.GetComponent<InventoryItem>().getItemName();
        Debug.Log(itemName);
    }


    void Update()
    {
        if (isActive)
        {
            if (inRange && Input.GetKeyDown(KeyCode.E) && !isSafeOpened)
            {
                //when E is pressed, turn UI on or off, whichever it wasn't before
                if (UIopen == false)
                {
                    codePanel.SetActive(true);
                    UIopen = !UIopen;
                }
                else
                {
                    codePanel.SetActive(false);
                    UIopen = !UIopen;

                }
            }
        }

    }

    // used to update the safe state
    [PunRPC]
    private void openSafe()
    {
        //source.PlayOneShot(safeopening, 0.03f);
        Debug.Log("openSafe called");
        //hidden safe automatically adds the final key to the inventory
        inventory.GetComponent<Inventory>().photonView.RPC("addItem", PhotonTargets.All, itemName);
        networkTextBox.GetComponent<InteractText>().photonView.RPC("DisplayLook", PhotonTargets.All, "The " + itemName + " was taken and put in the inventory.");
        codePanel.SetActive(false);
        foundSafe.SetActive(false);
        isSafeOpened = true;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            //UI should turn off on it's own when no longer in range
            inRange = false;
            codePanel.SetActive(false);
            UIopen = !UIopen;
        }
    }



    [PunRPC]
    public void activate()
    {
        isActive = true;
    }


}
