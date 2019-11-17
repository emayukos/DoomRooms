using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
	public Animator animator;
	private int roomNumber = 1;
    public Text roomNumberText;
	private int levelToLoad;

    //void Update()
    //{
    //	if (Input.GetMouseButtonDown(0)) {
    //		FadeToNextLevel();
    //	} 
    //}
     
    public void FadeToNextLevel() 
    {
    	FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void FadeToLevel(int levelIndex) {
    	levelToLoad = levelIndex;
    	animator.SetTrigger("FadeOut");
    }
    
    public void OnFadeComplete() 
    {	
    	// get the room number to carry to the next room again (should move this somewhere else)
    	roomNumber += 1;
		roomNumberText.text = "Room: " + roomNumber; // update text 
    	SceneManager.LoadScene(levelToLoad);
    }
}
