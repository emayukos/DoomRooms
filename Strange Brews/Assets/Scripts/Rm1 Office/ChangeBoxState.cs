using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBoxState : Photon.MonoBehaviour
{
	[SerializeField]
	public GameObject boxButtonPrefab;
	
	public Sprite closedBox;
	public Sprite openBox;
	private bool inRange = false;
	//private bool buttonCreated = false;
	Vector2 initialButtonPosition;
	public Vector2 buttonPositionInScene;
	private AudioSource source;
	public AudioClip soundEffect;
	private bool isOpen = false;


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
			this.photonView.RPC("OpenBox", PhotonTargets.All);
		}
		
		
	}
	[PunRPC]
	void OpenBox()
	{
			// open box 
			GetComponent<SpriteRenderer>().sprite = openBox;
			isOpen = true;
			if (soundEffect != null)
            {
                source.PlayOneShot(soundEffect);
            }
            // move button object inside box if it hasn't been picked up
            //if (boxButtonPrefab.activeInHierarchy == true )
            if(boxButtonPrefab != null)
			{
            
                buttonPositionInScene = transform.position;
                buttonPositionInScene.y -= 0.5f;
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
			this.photonView.RPC("CloseBox", PhotonTargets.All);
		}
	}
	
	[PunRPC]
	void CloseBox()
	{
		if (isOpen)
		{
			// close box when player moves out of trigger boundary
			GetComponent<SpriteRenderer>().sprite = closedBox;

			if (soundEffect != null)
			{
				source.PlayOneShot(soundEffect);
			}
			if (boxButtonPrefab != null)
				boxButtonPrefab.transform.position = initialButtonPosition;
			isOpen = false;
		}
	}
	
	   // private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    // local players data
    //    if (stream.isWriting)
    //    {
    //        stream.SendNext(transform.position);
    //        stream.SendNext(transform.localScale);
    //    }
    //    else
    //    {
    //        selfPosition = (Vector3)stream.ReceiveNext();
    //        selfScale = (Vector3)stream.ReceiveNext();

    //    }
    //}
       
    
     //private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) 
}





