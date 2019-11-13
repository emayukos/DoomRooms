using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoverBoarder : MonoBehaviour
{
	public Material border;
	public Material nonBorder;
	
	void OnTriggerEnter2D(Collider2D col)
	{
		GetComponent<Renderer>().material = border;
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		GetComponent<Renderer>().material = nonBorder;
	}
	
	


}
