using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable; // need at top of script

public class Shrink : Photon.MonoBehaviour
{
	public float shrinkSpeed = 0.08f;
	public float shrunkSize = 0.2f;
	public bool shrink = false; // true when player should be shrinking
	private AudioSource source;
    public AudioClip pressSoundEffect;
    //Hashtable hash = new Hashtable();
    private GameObject tinyDoor;
    //GameObject networkTextBox;

	//private GameObject tinyDoor;
	//[System.Obsolete]
	public bool shrunk;

	// have cute/funny shrinking sound effect play only on key press 
	// (after pressing E and the sound effect for drinking the potion)

	[System.Obsolete]
	private void Start()
	{
		//networkTextBox = GameObject.Find("Network Message Text");
		source = GetComponent<AudioSource>();
		//ShrinkPlayer(); // just for testing sound
		shrunk = false;
		// need hashtable to set custom properties
		//hash.Add("shrunk", shrunk); 
		//PhotonNetwork.player.SetCustomProperties(hash);
		//shrunk = (bool)PhotonNetwork.player.customProperties["shrunk"];
	}

    // Update is called once per frame
    void Update()
    {
    	if(shrink) { 
			//networkTextBox.GetComponent<InteractText>().photonView.RPC("DisplayLook", PhotonTargets.All, "Player drank shrinking potion!");
			//playSound = false; // so only played once
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
    	photonView.RPC("ShrinkPlayer", PhotonTargets.All); // change to master for now
    }
    
    
    [PunRPC]
	public void ShrinkPlayer() {
		if (!shrunk) 
		{
			shrink = true;
			shrunk = true;
			//hash["shrunk"] = shrunk; // set to true
			//Debug.Log(PhotonNetwork.playerList[0].CustomProperties);
			//PhotonNetwork.player.SetCustomProperties(hash);
			//Debug.Log(PhotonNetwork.playerList[0].CustomProperties);
			//Debug.Log(PhotonNetwork.playerList[1].CustomProperties);
			
			if (pressSoundEffect != null)
			{
				source.PlayOneShot(pressSoundEffect, 2.0f);
			}
			//if ((bool)PhotonNetwork.playerList[0].CustomProperties["shrunk"] == true && (bool)PhotonNetwork.playerList[1].CustomProperties["shrunk"] == true)
			//{
			tinyDoor = GameObject.FindWithTag("tiny door"); // to make easier to find
			Debug.Log("found tiny door");
			tinyDoor.SendMessage("IsShrunkRPC");
			Debug.Log("calling door script");
			//

		}
    }
    
  //  public void doneShrinking() 
  //  { 
  //  	if(shrink)
		//{
			
		//}
    //}
    
    
}
