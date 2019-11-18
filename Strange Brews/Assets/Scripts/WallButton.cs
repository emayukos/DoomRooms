using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{	
	// make public until pickup script is working
    public bool isEnabled = false; // have buttons start off unpressable
	public bool isPressed = false;
	private bool inRange = false;
	public Sprite buttonUnpressed;
	public Sprite buttonPressed;

	private AudioSource source;
    public AudioClip pressSoundEffect;


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
				pressButton();
				// press sound effect only when first pressed
                if (pressSoundEffect != null)
                {
                    source.PlayOneShot(pressSoundEffect);
                }
				Debug.Log("pressed");
			}
			if(inRange && Input.GetKeyUp(KeyCode.E))
			{
				unpressButton();
			}

		}
	}
	
	void enableButton()
	{
		isEnabled = true;
	}
	
	void disableButton()
	{
		isEnabled = false;
	}
	
	
	void pressButton()  // only does something when button is enabled 
	{
		if (isEnabled)
		{
			GetComponent<SpriteRenderer>().sprite = buttonPressed;
			isPressed = true;
		}
	}
	
	void unpressButton()
	{
	 	GetComponent<SpriteRenderer>().sprite = buttonUnpressed;
		isPressed = false;
	}
	
	
	private void OnTriggerEnter2D(Collider2D col) 
	{
		inRange |= col.gameObject.CompareTag("Player");
	}
	
		private void OnTriggerExit2D(Collider2D col)
	{
		inRange &= !col.gameObject.CompareTag("Player");
	}
	
	
}


