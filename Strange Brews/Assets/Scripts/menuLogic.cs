using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuLogic : MonoBehaviour
{
	
	public void disableMenuUI()
	{
		PhotonNetwork.LoadLevel("MainMenu");
	}
}
