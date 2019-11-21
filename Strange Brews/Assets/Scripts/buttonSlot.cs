using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSlot : Photon.MonoBehaviour
{
	// on trigger enter
	// if E is pressed, check inventory for button (for now just use bool)
	// if hasButton, change slot sprite to wall-buttonPressed sprite
	// have both buttons start blinking until they are both pressed at the same time
	// both players must hold down a key 
	// so OnTriggerEnter, toggle button1InRange and button2InRange to true if both players are in OnTrigger Enter
	// in Update, if buttonInRange and key is held down, change sprite to button pressed down sprite
	// and toggle button1Pressed to true. if button1Pressed and button2Pressed, both buttons permanantly 
	// get the button pressed sprite and they stop blinking. picture frame moves up and 
	// safe is revealed
	public GameObject wallButton1; // need to put in scene outside of camera view before running 
	public GameObject wallButton2; // initially in wall
	public GameObject painting;
	bool inRange = false;  // player is at slot
	Vector2 initialButtonPosition; // initially have outside of scene somewhere
	public Vector2 buttonPositionInScene;
	bool playerHasButton = false;
	bool buttonInWall = false;
	bool buttonTaskCompleted = false; // need rpc
	

	private void Start()
	{
		initialButtonPosition = wallButton1.transform.position;
	}

	private void Update()
	{
		// press G to get button from inventory
		// won't do anything if player doesn't have the button yet
		if (!buttonTaskCompleted)
		{
			if (wallButton1.GetComponent<WallButton>().isPressed && wallButton2.GetComponent<WallButton>().isPressed)
			{
				// keep both buttons pressed
				tempFunctionRPC();				
			}

			if (inRange && Input.GetKeyDown(KeyCode.G))
			{
				if (GameObject.Find("Inventory").GetComponent<Inventory>().searchItem("buttonUnpressed"))
				{
					// put button 1 in wall
					//Instantiate(wallButton1, buttonPositionInScene, Quaternion.identity);
					putButtonInWallRPC();
					
				}
				else
				{
					Debug.Log("not working");
				}

			}

			//if (inRange && buttonInWall)
			//{
			//	if (Input.GetKeyDown(KeyCode.E)) // press E to press button
			//	{
			//		// pressing button
			//		wallButton1.SendMessage("pressButton");
			//		// stop blinking
			//		// if both buttons are pressed, keep them both pressed down
			//	}
			//	else // unpress button
			//	{
			//		wallButton1.SendMessage("unpressButton");
			//	}

			//}
		}



	}

	private void OnTriggerEnter2D(Collider2D col) // change this to on button press
	{
		inRange |= col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine;
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		inRange &= !(col.gameObject.CompareTag("Player") && col.GetComponent<PhotonView>().isMine);
	}
	
	
	
	void tempFunctionRPC()
	{
		photonView.RPC("tempFunction", PhotonTargets.All);
	}
	
	[PunRPC]
	void tempFunction()
	{
		buttonTaskCompleted = true;
		Debug.Log("button task completed!");
		// have both buttons be in pressed state and keep like that
		// send message to function on painting object
		//painting.SendMessage("movePainting"); // change to RPC later
		painting.SendMessage("movePaintUp");
	}
	
	
	
	void putButtonInWallRPC()
	{
		photonView.RPC("putButtonInWall", PhotonTargets.All);
	}
	
	[PunRPC]
	void putButtonInWall()
	{
		wallButton1.transform.position = buttonPositionInScene;
		// make both buttons pressable
		wallButton1.SendMessage("enableButton");
		wallButton2.SendMessage("enableButton");
		// have this and the other button light up and blink
		buttonInWall = true;
	}
}
