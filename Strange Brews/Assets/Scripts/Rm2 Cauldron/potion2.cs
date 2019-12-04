using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potion2 : Photon.MonoBehaviour
{
	// make public until pickup script is working
	public bool drank = false;
	private bool inRange = false;
	//public Sprite fullBottle;
	public GameObject emptyBottlePrefab;

	private AudioSource source;
    public AudioClip drinkSoundEffect;
	private GameObject Player;
	private PhotonPlayer photonPlayer;
	//private tinydoor tinyDoor;
	// only send message after second potion is drunk
	private GameObject tinyDoor;
	GameObject networkTextBox;
	//public GameObject potion2Prefab;
	//public bool stop = false;
	//private GameObject thisplayer; // figure out how to do this individually

	private void Awake()
	{
		//Player = GameObject.FindWithTag("Player");
		
	}

	private void Start()
	{
		networkTextBox = GameObject.Find("Network Message Text");
		tinyDoor = GameObject.FindWithTag("tiny door"); // to make easier to find
		source = GetComponent<AudioSource>();
		
		
		
		// disable script on other potion until this one is destroyed
		//potion2Prefab.GetComponent<potion2>().enabled = false;

		//Player = GameObject.FindWithTag("Player");
		//isActive(true); // for testing
	}



	private void Update()
	{
		// if both players are shrunk (and this script hasn't been called yet
			// set empty bottle sprite to active and destroy self
		if(PhotonNetwork.playerList.Length > 1)
		{
			if ((bool)PhotonNetwork.playerList[0].CustomProperties ["shrunk"] == true && 
				(bool)PhotonNetwork.playerList[1].CustomProperties ["shrunk"] == true)
			{
			
				networkTextBox.GetComponent<InteractText>().photonView.RPC("DisplayLook", PhotonTargets.All, "Both players drank shrinking potion!");
				Instantiate(emptyBottlePrefab, transform.position, Quaternion.identity, null);
				Destroy(gameObject);
				tinyDoor.SendMessage("IsShrunk");
			}

		}

		// elif other player clicked potion, shrink player and do above
		// make potion script for other player that checks that it's not their view
		else if(inRange && Input.GetKeyDown(KeyCode.E)) 
		{
			if(!(Player.GetComponent<Shrink>().shrunk)) // if player hasn't shrunk already
			{
				networkTextBox.GetComponent<InteractText>().photonView.RPC("DisplayLook", PhotonTargets.All, "second player drank shrinking potion!");
				drinkPotionRPC();
			}
			
			//stop = true;
		}
		

	}
	
	void drinkPotionRPC()
	{
		photonView.RPC("drinkPotion", PhotonTargets.All); // switching prefabs should be for all!
		
	}


	[PunRPC]
	IEnumerator drinkPotion()  // don't know if allowed to use this format so test
	{
		source.clip = drinkSoundEffect;
		source.Play();
		Debug.Log("player drank potion");
		yield return new WaitForSeconds(source.clip.length);
		//GetComponent<SpriteRenderer>().sprite =;
		Instantiate(emptyBottlePrefab, transform.position, Quaternion.identity, null);
		//GetComponent<SpriteRenderer>().sprite = emptyBottle;
		//potion2Prefab.GetComponent<potion2>().enabled = false;
		Destroy(gameObject);
		//if(Player.PhotonView.isMine)
		Player.SendMessage("ShrinkPlayerRPC");
		tinyDoor.SendMessage("IsShrunk");
	}
	
	//// call shrink player RPC for photonPlayer
	//void callShrink() 
	//{ 
	//	Player.SendMessage("ShrinkPlayerRPC");
	//}
	
	
	
	// for player 1
	private void OnTriggerEnter2D(Collider2D col) 
	{
		//inRange |= (col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine);
		if (col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine)
		{
			photonPlayer = PhotonView.Get(col.transform.gameObject).owner; // get the player 
			inRange = true;
			// need to assign player too! 
			Player = col.transform.gameObject;
			//if(photonPlayer.isMasterClient)

			
		}
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		inRange &= !(col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine);
	}

}
