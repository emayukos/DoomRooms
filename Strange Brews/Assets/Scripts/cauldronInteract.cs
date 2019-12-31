using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// emma
public class cauldronInteract : MonoBehaviour
{

    public GameObject potion1;
    private interactWithUI iwUI;

    private AudioSource source;
    public AudioClip brewPotionSound;

    private void Start()
    {
        // hide the potion
        potion1.SetActive(false);
        // this is what will deal with the cauldron UI
        iwUI = GetComponent<interactWithUI>();
        // for playing sounds
        source = GetComponent<AudioSource>();
    }

    [PunRPC] // has to be an RPC to happen for both players
    public void brewPotion()
    {
        // when the potion is brewed, show it
        potion1.SetActive(true);
        source.PlayOneShot(brewPotionSound);
        // deactivate the UI so it can't be opened anymore
        iwUI.deactivate();
    }


}