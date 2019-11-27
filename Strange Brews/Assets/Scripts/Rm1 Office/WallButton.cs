using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : Photon.MonoBehaviour
{	
	// make public until pickup script is working
    public bool isEnabled = false; // have buttons start off unpressable
	public bool isPressed = false;
	private bool inRange = false;
	public Sprite buttonUnpressed;
	public Sprite buttonPressed;

	private AudioSource source;
    public AudioClip pressSoundEffect;

    public Light greenlight;
    bool lightOn = false;


	// can have another script that makes buttons blink if you wanted to

	private void Start()
	{
		source = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if(isEnabled) // can only press button after we've enabled it from another script
		{
			if(inRange && Input.GetKeyDown(KeyCode.E)) 
			{
				pressButtonRPC();
			}
			if(inRange && Input.GetKeyUp(KeyCode.E))
			{
				unpressButtonRPC();
			}

            if (lightOn)
            {
                // turn on light
                greenlight.gameObject.SetActive(true);
            }
            else
            {
                //turn off light
                greenlight.gameObject.SetActive(false);
            }

		}

	}
	
	void enableButtonRPC()
	{
		photonView.RPC("enableButton", PhotonTargets.All);
	}
	
	void disableButtonRPC()
	{
		photonView.RPC("disableButton", PhotonTargets.All);
	}
	
	void pressButtonRPC()
	{
		photonView.RPC("pressButton", PhotonTargets.All);
	}
	
	void unpressButtonRPC()
	{
		photonView.RPC("unpressButton", PhotonTargets.All);
    }
	
	
	[PunRPC] 
	void enableButton()
	{
		isEnabled = true;
	}
	[PunRPC] 
	void disableButton()
	{
		isEnabled = false;
	}
	
	[PunRPC] 
	void pressButton()  // only does something when button is enabled 
	{
		if (isEnabled)
		{
			GetComponent<SpriteRenderer>().sprite = buttonPressed;
			isPressed = true;
			// press sound effect only when first pressed
           if (pressSoundEffect != null)
            {
                source.PlayOneShot(pressSoundEffect);
            }
			Debug.Log("pressed");
            lightOn = true;
		}
	}
	[PunRPC] 
	void unpressButton()
	{
	 	GetComponent<SpriteRenderer>().sprite = buttonUnpressed;
		isPressed = false;
        lightOn = false;
	}
	
	
	private void OnTriggerEnter2D(Collider2D col) 
	{
		inRange |= (col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine);
	}
	
	private void OnTriggerExit2D(Collider2D col)
	{
		inRange &= !(col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine);
	}
	
	
}


