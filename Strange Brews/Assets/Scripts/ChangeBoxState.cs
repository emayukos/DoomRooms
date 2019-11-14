using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBoxState : MonoBehaviour
{
	public Sprite closedBox;
	public Sprite openBox;
	public GameObject buttonPrefab;
	private bool inRange = false;
	private bool buttonCreated = false;
	Vector2 initialButtonPosition;


	private void Start()
	{
		initialButtonPosition = buttonPrefab.transform.position;
	}


	private void Update()
	{
		if(inRange)
		{
			// open box 
			GetComponent<SpriteRenderer>().sprite = openBox;
            // instantiate button object
            if (!buttonCreated)
			{
				buttonPrefab.transform.position = transform.position;
			    //Instantiate(buttonPrefab, transform.position, Quaternion.identity);
				buttonCreated = true;
			}
		}
		
	}

	private void OnTriggerEnter2D(Collider2D col) // change this to on button press
	{
		if (col.gameObject.CompareTag("Player"))
        {
			inRange = true;
        }
	}
	
		private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Player"))
        {
			inRange = false;
            // close box when player moves out of trigger boundary
            GetComponent<SpriteRenderer>().sprite = closedBox;
            
            // if button object exists, destroy it
            if(buttonCreated)
			{
				buttonPrefab.transform.position = initialButtonPosition;
				buttonCreated = false;
			}
        }
	}



}
