using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : Photon.MonoBehaviour
{
	public Animator animator;
	private int roomNumber = 1;
    public Text roomNumberText;
	private int levelToLoad;
	public AudioClip unlockSound;
	//public AudioClip doorOpenSound;
	private AudioSource source;
	
	private GameObject leftDoor;
	Vector2 temp;
	private GameObject[] players;
	public Vector2 startPos;

	//void Update()
	//{
	//	if (Input.GetMouseButtonDown(0)) {
	//		FadeToNextLevel();
	//	} 
	//}

	//private void Awake()
	//{
	//	DontDestroyOnLoad(this.transform);
	//}

	private void Awake()
	{	
		players = GameObject.FindGameObjectsWithTag("Player");
		players[0].transform.position = startPos;
		startPos.x -= 0.25f;
		startPos.y += 1;
		if (players.Length > 1)
		{
			players[1].transform.position = startPos;
		}
		
	}




	private void Start()
    {
        //Fetch the GameObject's Collider (make sure they have a Collider component)
        roomNumberText.text = "Room: " + (SceneManager.GetActiveScene().buildIndex - 1);
        source = GetComponent<AudioSource>(); // need this!
        if (GameObject.Find("leftdoor") != null) {
			leftDoor = GameObject.Find("leftdoor");
			temp.x = leftDoor.transform.position.x + 1;
			temp.y = leftDoor.transform.position.y + 1;
			gameObject.transform.position = temp;
		 
		}

	
        
    }

	void FadeToNextLevelRPC()
	{
		photonView.RPC("FadeToNextLevel", PhotonTargets.All);
	}



	[PunRPC]
	void FadeToNextLevel() 
    {
    	if (unlockSound != null)
		{
			source.PlayOneShot(unlockSound);
		}
		//if (doorOpenSound != null)
		//{
		//	source.PlayOneShot(doorOpenSound);
		//}
    	FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    
    
    
    
    public void FadeToLevel(int levelIndex) {
    	levelToLoad = levelIndex;
    	animator.SetTrigger("FadeOut");
    }
    

    void OnFadeComplete() 
    {	
    	// get the room number to carry to the next room again (should move this somewhere else)
    	roomNumber += 1;
		roomNumberText.text = "Room: " + roomNumber; // update text 
		PhotonNetwork.LoadLevel(levelToLoad);
    	//SceneManager.LoadScene(levelToLoad);
    }
}
