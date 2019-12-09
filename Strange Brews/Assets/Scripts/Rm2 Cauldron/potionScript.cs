using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionScript : Photon.MonoBehaviour
{
	// make public until pickup script is working
	public bool drank = false;
	private bool inRange = false;
	private AudioSource source;
    public AudioClip drinkSoundEffect;
	private GameObject Player;
	GameObject networkTextBox;

	private void Start()
	{
		networkTextBox = GameObject.Find("Network Message Text");
		source = GetComponent<AudioSource>();
	}

	private void Update()
	{
		// for shrinking both players
		if(inRange && Input.GetKeyDown(KeyCode.E)) 
		{
			drinkPotionRPC();
		}

	}
	
	void drinkPotionRPC()
	{
		photonView.RPC("drinkPotion", PhotonTargets.All); // switching prefabs should be for all!
		
	}


	[PunRPC]
	IEnumerator drinkPotion()  // IEnumerator to call sound effects in sequence
	{
		source.clip = drinkSoundEffect;
		source.Play();
		networkTextBox.GetComponent<messageBox>().photonView.RPC("MessageDisplayLook", PhotonTargets.All, "drank shrinking potion!");
		yield return new WaitForSeconds(source.clip.length);
		Player.SendMessage("ShrinkPlayerRPC");

		
	}
		
	private void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine)
		{ 
			inRange = true;
			// need to assign player too 
			Player = col.transform.gameObject;

			
		}
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		inRange &= !(col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine);
	}

}


