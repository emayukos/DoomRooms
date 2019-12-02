using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OnEnterClassroom : MonoBehaviour
{
    public AudioClip unlockSound;
    public AudioClip doorOpenSound;
    public AudioClip doorCloseSound;
    public AudioClip creepyTeacher;
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>(); // need this!
                                              //GetComponent<AudioSource> ().loop = true;
        StartCoroutine(playEngineSound());
    }

    IEnumerator playEngineSound()
    {
        source.clip = doorOpenSound;
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
        source.clip = doorCloseSound;
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
        source.clip = creepyTeacher;
        source.Play();
    }
}
