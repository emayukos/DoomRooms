using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
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
	

	// Update is called once per frame
	void Update()
    {
        
    }
}
