using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : Photon.MonoBehaviour
{
	public float shrinkSpeed = 0.08f;
	public float shrunkSize = 0.2f;
	public bool shrink = false; // true when player should be shrinking
	private AudioSource source;
    public AudioClip pressSoundEffect;

    // have cute/funny shrinking sound effect play only on key press 
    // (after pressing E and the sound effect for drinking the potion)
    
    private void Start()
	{
		source = GetComponent<AudioSource>();
		//ShrinkPlayer(); // just for testing sound
	}

    // Update is called once per frame
    void Update()
    {
    	if(shrink) { 

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
    	photonView.RPC("ShrinkPlayer", PhotonTargets.All);
    }
    
    
    [PunRPC]
    public void ShrinkPlayer() {
		shrink = true;
		if (pressSoundEffect != null)
            {
                source.PlayOneShot(pressSoundEffect);
            }
    }
    
}
