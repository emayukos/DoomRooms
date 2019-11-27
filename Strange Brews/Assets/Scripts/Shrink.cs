using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour
{
	public Rigidbody2D rb;
	public float shrinkSpeed = 1.0f;
	Vector3 normalScale;
	public bool shrink; // true when player should be shrinking
    // Start is called before the first frame update
    void Start()
    {
		normalScale = transform.localScale; // save players original size for the next room maybe will probably just save this value and put in grow script tho

    }
    
    // have cute/funny shrinking sound effect play only on key press 
    // (after pressing E and the sound effect for drinking the potion)

    // Update is called once per frame
    void Update()
    {
    	if(shrink) { 
    		//Scale this game object
 			transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
 			// stop when small enough
 			if (transform.localScale.x <= .1f) {
				shrink = false;
 			}
 			
    	}
    	
        
    }
}
