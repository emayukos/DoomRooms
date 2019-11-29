using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class potion : Photon.MonoBehaviour
{

	// make public until pickup script is working
	public bool drank = false;
	private bool inRange = false;
	public Sprite fullBottle;
	public Sprite emptyBottle;

	private AudioSource source;
    public AudioClip drinkSoundEffect;
	private GameObject Player;
	private GameObject thisplayer; // figure out how to do this individually
	
	

	private void Start()
	{
		source = GetComponent<AudioSource>();
		Player = GameObject.FindWithTag("Player");	
	}

	private void Update()
	{
		// make potion script for other player that checks that it's not their view
		if(inRange && Input.GetKeyDown(KeyCode.E)) 
		{
			drinkPotionRPC();
			
		}

	}
	
	void drinkPotionRPC()
	{
		photonView.RPC("drinkPotion", PhotonTargets.All);
	}


	[PunRPC]
	IEnumerator drinkPotion()  // don't know if allowed to use this format so test
	{
		source.clip = drinkSoundEffect;
		source.Play();
		Debug.Log("player drank potion");
		yield return new WaitForSeconds(source.clip.length);
		GetComponent<SpriteRenderer>().sprite = emptyBottle;
		thisplayer.SendMessage("ShrinkPlayerRPC");
	}
	
	// for player 1
	private void OnTriggerEnter2D(Collider2D col) 
	{
		inRange |= (col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine);
	}
	
	private void OnTriggerExit2D(Collider2D col)
	{
		inRange &= !(col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine);
	}


}
