using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tinydoor : Photon.MonoBehaviour
{
	bool inRange = false;
	public Material border;
	public Material unborder;
	public GameObject levelChanger;
	public bool hasFinalKey = false;
	GameObject inventory;
	public bool isShrunk = false; // player can only go through door after drinking shrinking potion
	GameObject networkTextBox;
	
	private AudioSource source;
    public AudioClip messageSound;
	
	void Start()
    {
    	source = GetComponent<AudioSource>();
        inventory = GameObject.Find("Inventory");
        networkTextBox = GameObject.Find("Network Message Text");
    }

	private void Update()
	{
		if (inRange && hasFinalKey && Input.GetKeyDown(KeyCode.E))
		{
			// can only go through door after shrinking
			// check players shrink boolean
			if(isShrunk)
			{
				// unlock door and go to next room
				levelChanger.SendMessage("FadeToNextLevelRPC");
				Debug.Log("unlocked door");
			}
			// otherwise let players know there are other tasks to complete
			else
			{
				Debug.Log("player(s) can't fit through door!");
				                //adds item to multiplayer inventory text box
				if (messageSound != null)
            	{
                	source.PlayOneShot(messageSound);
            	}
                networkTextBox.GetComponent<messageBox>().photonView.RPC("MessageDisplayLook", PhotonTargets.All, "One or more players too big to fit through door!");
			}

		}
	}

	void OnTriggerEnter2D(Collider2D col) // if this doesn't work revert back to on collision enter (need to check trigger)
    {
        if (col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine) // will only recognize this when the player has the key and is a trigger
        {
			inRange = true;
            Debug.Log("Player touched door.");
			if (inventory.GetComponent<Inventory>().searchItem("Final Key"))
            {
				hasFinalKey = true;
            	GetComponent<Renderer>().material = border; // give door border indicating it can be unlocked
                Debug.Log("Player has key. Can press E to unlock door.");
            }
        }
    }
    
    void OnTriggerExit2D(Collider2D col) 
    { 
    	inRange = false;
    	GetComponent<Renderer>().material = unborder;
    }
    

    
    public void IsShrunkRPC() { 
    	photonView.RPC("IsShrunk", PhotonTargets.All); // change to master for now
    }
    
    [PunRPC]
    void IsShrunk() {
		isShrunk = true;
    }
    
}


