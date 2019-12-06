using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cauldronInteract : MonoBehaviour
{

    public GameObject potion1;
    private interactWithUI iwUI;

    private AudioSource source;
    public AudioClip brewPotionSound;

    private void Start()
    {
        potion1.SetActive(false);
        //potion2.SetActive(false);
        iwUI = GetComponent<interactWithUI>();
        source = GetComponent<AudioSource>();
    }

    [PunRPC]
    public void brewPotion()
    {

        potion1.SetActive(true);
        //potion2.SetActive(true);

        source.PlayOneShot(brewPotionSound);

        iwUI.deactivate();
    }


}