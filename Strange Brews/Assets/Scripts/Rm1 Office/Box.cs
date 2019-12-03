using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Photon.MonoBehaviour
{
	[SerializeField]
	//public GameObject boxButtonPrefab;
	
	public GameObject closedBox;
	public GameObject openBox;
	private bool inRange = false;
	//private bool buttonCreated = false;
	//Vector2 initialButtonPosition;
	//public Vector2 buttonPositionInScene;
	private AudioSource source;
	public AudioClip soundEffect;
	private bool isOpen = false;
	//public string sortingLayerClosed = "furniture 2";
	//public int sortingOrderClosed = 2;
	//public string sortingLayerOpen = "accessory 2.2";
	//public int sortingOrderOpen = 3; // to hide cobwebs, etc.
	


	private void Start()
	{
		//initialButtonPosition = boxButtonPrefab.transform.position;
		// -3.488, -3.61, 0
		source = GetComponent<AudioSource>();
		openBox.SetActive(false);
		
	}


	private void Update()
	{
		if(inRange && Input.GetKeyDown(KeyCode.E)) // make icon that says "press E" to open
		{
			if (isOpen)
			{
				photonView.RPC("CloseBox", PhotonTargets.All);
			}
			else
			{
				photonView.RPC("OpenBox", PhotonTargets.All);
			}
		
		}
		
		
	}
	[PunRPC]
	void OpenBox()
	{
		// open box 
		//GetComponent<SpriteRenderer>().sprite = openBox;
		//GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerOpen;
		//GetComponent<SpriteRenderer>().sortingOrder = sortingOrderOpen;
		closedBox.SetActive(false); 
		openBox.SetActive(true);
		
			isOpen = true;
			if (soundEffect != null)
            {
                source.PlayOneShot(soundEffect, 2.0f);
            }
            // move button object inside box if it hasn't been picked up
            //if (boxButtonPrefab.activeInHierarchy == true )
   //         if(boxButtonPrefab != null)
			//{
            
   //             buttonPositionInScene = transform.position;
   //             buttonPositionInScene.y -= 0.5f;
			//	boxButtonPrefab.transform.position = buttonPositionInScene;
			//    //Instantiate(buttonPrefab, transform.position, Quaternion.identity);
			//	//buttonCreated = true;
				
			//}	
	
	}
	

	private void OnTriggerEnter2D(Collider2D col) // change this to on button press
	{
		inRange |= col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine;
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine)
		{
			inRange = false;
			this.photonView.RPC("CloseBox", PhotonTargets.All);
		}
	}
	
	[PunRPC]
	void CloseBox()
	{
		if (isOpen)
		{
			// close box when player moves out of trigger boundary
			//GetComponent<SpriteRenderer>().sprite = closedBox;
			//GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerClosed;
			//GetComponent<SpriteRenderer>().sortingOrder = sortingOrderClosed;
			closedBox.SetActive(true); 
			openBox.SetActive(false);

			if (soundEffect != null)
			{
				source.PlayOneShot(soundEffect);
			}
			//if (boxButtonPrefab != null)
				//boxButtonPrefab.transform.position = initialButtonPosition;
			isOpen = false;
		}
	}
}
