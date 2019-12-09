using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Photon.MonoBehaviour
{
	[SerializeField]

	public GameObject closedBox;
	public GameObject openBox;
	private bool inRange = false;

	private AudioSource source;
	public AudioClip soundEffect;
	private bool isOpen = false;

	private void Start()
	{
		source = GetComponent<AudioSource>();
		openBox.SetActive(false);
		
	}


	private void Update()
	{
		if(inRange && Input.GetKeyDown(KeyCode.E)) // make icon that says "press E" to open
		{
			if (!isOpen)
			{
				photonView.RPC("OpenBox", PhotonTargets.All);
			}
		
		}
		
		
	}
	[PunRPC]
	void OpenBox()
	{
		closedBox.SetActive(false); 
		openBox.SetActive(true);
		
			isOpen = true;
			if (soundEffect != null)
            {
                source.PlayOneShot(soundEffect, 2.0f);
            }
	}
	

	private void OnTriggerEnter2D(Collider2D col) 
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
			closedBox.SetActive(true); 
			openBox.SetActive(false);

			if (soundEffect != null)
			{
				source.PlayOneShot(soundEffect);
			}
			isOpen = false;
		}
	}
}
