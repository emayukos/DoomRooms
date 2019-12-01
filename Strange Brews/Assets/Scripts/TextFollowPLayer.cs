using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFollowPLayer : MonoBehaviour
{
	// add the following variables to get desired camera position
	private Transform player; // have this reference our spaceship object by dragging object into spaceship slot created by this variable in unity 
							  // Vector3 datatype stores 3 floats (x,y,z)
							  //public Vector3 offset; // lets us specify x,y,z values in unity 
							  //                                             // want to move camera up and back so camera is not positioned directly in the center of the player (don't want first person POV)
							  //                                             // set z= -2 to make viewable
							  //                                             // deleted Start() method
	public Canvas canvas;


	//private void Start()
	//{
	//    spaceship = GameObject.Find("spaceship").transform;
	//}
	//// Update is called once per frame
	//void Update()
	//{
	//    // transform refers to the transform that this script is sitting on 
	//    transform.position = spaceship.position + offset;  // set main camera position = to player (center) position + desired distance from player position each frame 
	//    Debug.Log(spaceship.position);
	//}

	Vector3 tempVec3 = new Vector3();

	private void Awake()
	{
		player = canvas.GetComponentInParent<Transform>();
	}

	// call update (lateupdate caused glitchy bg)
	private void Update()
	{
		tempVec3.x = transform.position.x;
		tempVec3.y = player.position.y + 6;
		tempVec3.z = transform.position.z;
		transform.position = tempVec3;
	}
}

