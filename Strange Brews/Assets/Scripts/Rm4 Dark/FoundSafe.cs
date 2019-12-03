using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundSafe : MonoBehaviour
{
    public GameObject safe;
    public PhotonView photonview;
    public SpriteRenderer foundSafeSprite;
    public GameObject networkTextBox;

    private bool inRange = false;
    private Color originalColour;

    // Start is called before the first frame update
    void Start()
    {
        //safe.SetActive(false);
        originalColour = foundSafeSprite.color;
        foundSafeSprite.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            networkTextBox.GetComponent<InteractText>().photonView.RPC("DisplayLook", PhotonTargets.All, "Pushing a brick revealed a hidden safe.");
            foundSafeSprite.color = originalColour;
            this.photonview.RPC("activate", PhotonTargets.All, gameObject);
            ///safe.GetComponent<HiddenSafe>().activate(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            inRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            inRange = false;
        }
    }


}
