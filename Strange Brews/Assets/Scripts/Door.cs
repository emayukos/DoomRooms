using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : Photon.MonoBehaviour
{
	bool inRange = false;
	public Material border;
	public Material unborder;
	public GameObject levelChanger;
	public bool hasFinalKey = false;
	GameObject inventory;
	
	void Start()
    {
        //find fixed game objects that will be updated with interactions
        inventory = GameObject.Find("Inventory");
    }


	private void Update()
	{
		if (inRange && hasFinalKey && Input.GetKeyDown(KeyCode.E))
		{
			// unlock door and go to next room
			levelChanger.SendMessage("FadeToNextLevelRPC");
			Debug.Log("unlocked door");
		}
	}

	void OnTriggerEnter2D(Collider2D col)
    {
    		 // will only recognize this when the player has the key and is a trigger
        if (col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine) 
        {
			 		inRange = true;
            Debug.Log("Player touched door.");
					if (inventory.GetComponent<Inventory>().searchItem("Final Key"))
            {
						 hasFinalKey = true;
            		 GetComponent<Renderer>().material = border; // give door border (shader) indicating it can be unlocked
                Debug.Log("Player has key. Can press E to unlock door.");
            }
        }
    }
    
    void OnTriggerExit2D(Collider2D col) 
    { 
    	inRange = false;
    	GetComponent<Renderer>().material = unborder;
    }
    
}
