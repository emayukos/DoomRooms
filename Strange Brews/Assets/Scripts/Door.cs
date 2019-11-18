using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : Photon.MonoBehaviour
{
    //public PolygonCollider2D player; // move player object into this variable in Unity >> want to change scenes when player touches door and has key
    private int roomNumber = 1;
    public Text roomNumberText;
    public Door controller; // might need this might not
    //public Inventory Inventory;
	public bool hasFinalKey = false;
	bool inRange = false;
	public Material border;
	public Material unborder;
	public AudioClip unlockSound;
	public AudioClip doorOpenSound;
	private AudioSource source;
	public GameObject levelChanger;

    private void Start()
    {
        //Fetch the GameObject's Collider (make sure they have a Collider component)
        roomNumberText.text = "Room: " + roomNumber;
        source = GetComponent<AudioSource>(); // need this!
        
    }

	private void Update()
	{
		if (inRange && hasFinalKey && Input.GetKeyDown(KeyCode.E))
		{
			// unlock door and go to next room
			Debug.Log("unlocked door");
			if (unlockSound != null)
			{
				source.PlayOneShot(unlockSound);
			}
			if (doorOpenSound != null)
			{
				source.PlayOneShot(doorOpenSound);
			}
			levelChanger.SendMessage("FadeToNextLevel");
			//roomNumber += 1;
			//roomNumberText.text = "Room: " + roomNumber; // update text 
			//SceneManager.LoadScene("Room2"); // name of scene >> will destroy this game object
		}
	}

	void OnTriggerEnter2D(Collider2D col) // if this doesn't work revert back to on collision enter (need to check trigger)
    {
        if (col.gameObject.CompareTag("Player")) // will only recognize this when the player has the key and is a trigger
        {
			inRange = true;
            Debug.Log("Player touched door.");
            //if(Inventory.hasFinalKey())
            if(hasFinalKey)
            {	
            	GetComponent<Renderer>().material = border; // give door border indicating it can be unlocked
                Debug.Log("Player has key. Can press E to unlock door.");
            }
            //else {
                //Debug.Log("Player doesn't have key.");
            //}
        }
    }
    
    void OnTriggerExit2D(Collider2D col) 
    { 
    	inRange = false;
    	GetComponent<Renderer>().material = unborder;
    }
    
}
