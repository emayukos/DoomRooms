using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipmat : Photon.MonoBehaviour
{
	[SerializeField]
		
	public Sprite closedBox;
	public Sprite openBox;
	private bool inRange = false;
	public GameObject key;
	private bool isOpen = false;
	


	private void Start()
	{
		key.SetActive(false);
		
	}


	private void Update()
	{
		if(inRange && Input.GetKeyDown(KeyCode.E)) 
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
	

	private void OnTriggerEnter2D(Collider2D col) 
	{
		inRange |= col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine;
	}

    private void OnTriggerExit2D(Collider2D col) 
    {
        inRange = false;
    }
}
