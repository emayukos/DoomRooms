using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Grow : Photon.MonoBehaviour
{
	public float growSpeed = 0.08f;
	public float originalSize = 0.5f;
	public bool grow = false; // true when player should be shrinking
	private AudioSource source;
    public AudioClip growSoundEffect; 
    
    private void Start()
	{
		source = GetComponent<AudioSource>();

	}

    // Update is called once per frame
    void Update()
    {
    	if(grow) { 
    		//Scale this game object
 			transform.localScale += Vector3.one * growSpeed * Time.deltaTime;
 			// stop when small enough
 			if(transform.localScale.x >= originalSize) {
				grow = false;
 			}
    	}  
    }
    
    public void GrowPlayerRPC()
	{
		photonView.RPC("GrowPlayer", PhotonTargets.All);
	}
    
    [PunRPC]
    public void GrowPlayer() {
		grow = true;
		if (growSoundEffect != null)
            {
                source.PlayOneShot(growSoundEffect);
            }
    }
}


