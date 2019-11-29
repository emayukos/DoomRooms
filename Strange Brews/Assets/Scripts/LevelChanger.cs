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
	private void Start()
    {
        //Fetch the GameObject's Collider (make sure they have a Collider component)
        roomNumberText.text = "Room: " + roomNumber;
        source = GetComponent<AudioSource>(); // need this!
        
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
    	SceneManager.LoadScene(levelToLoad);
    }
}
