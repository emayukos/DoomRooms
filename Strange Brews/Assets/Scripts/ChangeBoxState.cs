using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBoxState : MonoBehaviour
{
	public Sprite closedBox;
	public Sprite openBox;
	public GameObject boxButtonPrefab;
	private bool inRange = false;
	//private bool buttonCreated = false;
	Vector2 initialButtonPosition;
	public Vector2 buttonPositionInScene;
	private AudioSource source;
	public AudioClip soundEffect;


	private void Start()
	{
		initialButtonPosition = boxButtonPrefab.transform.position;
		// -3.488, -3.61, 0
		source = GetComponent<AudioSource>();
		
	}


	private void Update()
	{
		if(inRange && Input.GetKeyDown(KeyCode.E)) // make icon that says "press E" to open
		{
			OpenBox();
		}
		
	}
	[PunRPC]
	private void OpenBox()
	{
			// open box 
			GetComponent<SpriteRenderer>().sprite = openBox;
			if (soundEffect != null)
            {
                source.PlayOneShot(soundEffect);
            }
            // move button object inside box if it hasn't been picked up
            //if (boxButtonPrefab.activeInHierarchy == true )
            if(GameObject.Find("buttonUnpressed") != null)
			{
				boxButtonPrefab.transform.position = buttonPositionInScene;
			    //Instantiate(buttonPrefab, transform.position, Quaternion.identity);
				//buttonCreated = true;
			}	
	
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
			CloseBox();
		}
	}
	
	[PunRPC]
	private void CloseBox()
	{

			// close box when player moves out of trigger boundary
			GetComponent<SpriteRenderer>().sprite = closedBox;

			if (soundEffect != null)
			{
				source.PlayOneShot(soundEffect);
			}
			if (GameObject.Find("buttonUnpressed") != null)
				boxButtonPrefab.transform.position = initialButtonPosition;
	}
       
    
     //private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) 
}





