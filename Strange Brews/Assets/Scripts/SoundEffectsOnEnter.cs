using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectsOnEnter : MonoBehaviour
{
	public AudioClip unlockSound;
	public AudioClip doorOpenSound;
	public AudioClip doorCloseSound;
    private AudioSource source;
    
    void Start()
    {
    	source = GetComponent<AudioSource>(); // need this!
		//GetComponent<AudioSource> ().loop = true;
		source.volume = 1.0f; // to lower volume
        StartCoroutine(playEngineSound());
    }
 
    IEnumerator playEngineSound()
    {
        source.clip =  doorOpenSound;
		source.Play();
        yield return new WaitForSeconds(source.clip.length);
        source.clip = doorCloseSound;
        source.Play();
    }
}
