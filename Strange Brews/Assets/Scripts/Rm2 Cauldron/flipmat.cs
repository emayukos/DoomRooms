using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipmat : Photon.MonoBehaviour
{
	[SerializeField]
	//public GameObject boxButtonPrefab;
	
	public Sprite closedBox;
	public Sprite openBox;
	private bool inRange = false;
	//private bool buttonCreated = false;
	//Vector2 initialButtonPosition;
	//public Vector2 buttonPositionInScene;
	public GameObject key;
	//private AudioSource source;
	//public AudioClip soundEffect;
	private bool isOpen = false;
	//public string sortingLayerClosed = "furniture 2";
	//public int sortingOrderClosed = 2;
	//public string sortingLayerOpen = "accessory 2.2";
	//public int sortingOrderOpen = 3; // to hide cobwebs, etc.
	


	private void Start()
	{
		//source = GetComponent<AudioSource>();
		key.SetActive(false);
		
	}


	private void Update()
	{
		if(inRange && Input.GetKeyDown(KeyCode.E)) // make icon that says "press E" to open
		{

			photonView.RPC("OpenBox", PhotonTargets.All);
		}
		
		
	}
	[PunRPC]
	void OpenBox()
	{
		// open box 
		GetComponent<SpriteRenderer>().sprite = openBox;

        if(key != null)
		{
				key.SetActive(true);
		}
		gameObject.GetComponent<Collider2D>().enabled = false;

	
	}
	

	private void OnTriggerEnter2D(Collider2D col) // change this to on button press
	{
		inRange |= col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine;
	}

    private void OnTriggerExit2D(Collider2D col) // change this to on button press
    {
        inRange = false;
    }



    //private void OnTriggerExit2D(Collider2D col)
    //{
    //	if (col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine)
    //	{
    //		inRange = false;
    //		this.photonView.RPC("CloseBox", PhotonTargets.All);
    //	}
    //}

    //[PunRPC]
    //void CloseBox()
    //{
    //if (isOpen)
    //{
    //	// close box when player moves out of trigger boundary
    //	GetComponent<SpriteRenderer>().sprite = closedBox;
    //	//GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerClosed;
    //	//GetComponent<SpriteRenderer>().sortingOrder = sortingOrderClosed;

    //	if (soundEffect != null)
    //	{
    //		source.PlayOneShot(soundEffect);
    //	}
    //	if (GameObject.Find("Final Key") != null)
    //		key.SetActive(false);
    //	isOpen = false;
    //}
    //}
}
