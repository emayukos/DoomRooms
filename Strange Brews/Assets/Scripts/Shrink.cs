using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Hashtable = ExitGames.Client.Photon.Hashtable; // need at top of script

public class Shrink : Photon.MonoBehaviour
{
	public float shrinkSpeed = 0.08f;
	public float shrunkSize = 0.2f;
	public bool shrink = false; // true when player should be shrinking
	private AudioSource source;
    public AudioClip shrinkSoundEffect;
    private GameObject tinyDoor;
	public bool shrunk;

	[System.Obsolete]
	private void Start()
	{
		source = GetComponent<AudioSource>();
		//ShrinkPlayer(); // just for testing sound
		shrunk = false;
	}

    // Update is called once per frame
    void Update()
    {
    	if(shrink) { 
    		//Scale this game object
 			transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
 			// stop when small enough
 			if(transform.localScale.x <= shrunkSize) {
				shrink = false;

 			}
    	}  
    }
    // call this in other script when you want the player to shrink
    public void ShrinkPlayerRPC() { 
    	photonView.RPC("ShrinkPlayer", PhotonTargets.All); 
    }
    
    
    [PunRPC]
	public void ShrinkPlayer() {
		if (!shrunk) 
		{
			shrink = true;
			shrunk = true;
			
			if (shrinkSoundEffect != null)
			{
				source.PlayOneShot(shrinkSoundEffect, 2.0f);
			}
			tinyDoor = GameObject.FindWithTag("tiny door"); // to make easier to find
			Debug.Log("found tiny door");
			tinyDoor.SendMessage("IsShrunkRPC");
			Debug.Log("calling door script");
		}
    }    
}
