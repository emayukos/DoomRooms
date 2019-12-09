using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerSafe : MonoBehaviour
{
    [SerializeField]
    GameObject codePanel, closedSafe, openedSafe, keyclue;
    public GameObject triggeredKey;

    public bool isSafeOpened = false; // should not initially be open
    private bool UIopen = false;
    private bool inRange = false;

    public AudioClip safeopening;
    private AudioSource source;


    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        //only the closed safe sprite should be visible until interacted with
        codePanel.SetActive(false);
        closedSafe.SetActive(true);
        openedSafe.SetActive(false);
        keyclue.SetActive(false);
        triggeredKey.SetActive(false);
    }


    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E) && !isSafeOpened)
        {
            //when E is pressed, turn UI on or off, whichever it wasn't before
            if (UIopen == false)
            {
                codePanel.SetActive(true);
                UIopen = !UIopen;
            }
            else
            {
                codePanel.SetActive(false);
                UIopen = !UIopen;

            }
        }

    }

    // used to update the safe state
    [PunRPC]
    private void openSafe()
    {
        source.PlayOneShot(safeopening, 0.03f);
        //disable further UI interaction
        codePanel.SetActive(false);
        closedSafe.SetActive(false);
        //show open safe and now available to grab key
        openedSafe.SetActive(true);
        keyclue.SetActive(true);
        triggeredKey.SetActive(true);
        isSafeOpened = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            //UI should turn off on it's own when no longer in range
            inRange = false;
            codePanel.SetActive(false);
            UIopen = !UIopen;
        }
    }

}
