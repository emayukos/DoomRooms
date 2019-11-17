using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBoxState : MonoBehaviour
{
	public Sprite closedBox;
	public Sprite openBox;
	public GameObject boxButtonPrefab;
	private bool inRange = false;
	private bool buttonCreated = false;
	Vector2 initialButtonPosition;
	public Vector2 buttonPositionInScene;


	private void Start()
	{
		initialButtonPosition = boxButtonPrefab.transform.position;
		// -3.488, -3.61, 0
	}


	private void Update()
	{
		if(inRange && Input.GetKeyDown(KeyCode.E)) // make icon that says "press E" to open
		{
			// open box 
			GetComponent<SpriteRenderer>().sprite = openBox;
            // move button object into scene (inside box)
            if (!buttonCreated)
			{
				boxButtonPrefab.transform.position = buttonPositionInScene;
			    //Instantiate(buttonPrefab, transform.position, Quaternion.identity);
				buttonCreated = true;
			}
		}
		
	}

	private void OnTriggerEnter2D(Collider2D col) // change this to on button press
	{
		inRange |= col.gameObject.CompareTag("Player");
	}
	
		private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Player"))
        {
			inRange = false;
            // close box when player moves out of trigger boundary
            GetComponent<SpriteRenderer>().sprite = closedBox;
            
            if(buttonCreated)
			{
				boxButtonPrefab.transform.position = initialButtonPosition;
				buttonCreated = false;
			}
        }
	}



}
