using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safe : MonoBehaviour
{
    [SerializeField]
    GameObject codePanel, closedSafe, openedSafe;

    private bool isActive;



    public bool isSafeOpened = false; // should not initially be open
    private bool UIopen = false;
    private bool isIn = false;

    public AudioClip safeopening;
    private AudioSource source;


    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        codePanel.SetActive(false);
        closedSafe.SetActive(true);
        openedSafe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (isIn && Input.GetKeyDown("e") && !isSafeOpened)
            {
                Debug.Log("pressed e");
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

    }

    // used to update the safe state
    [PunRPC]
    void openSafe()
    {
        

        source.PlayOneShot(safeopening, 0.03f);
        codePanel.SetActive(false);
        closedSafe.SetActive(false);
        openedSafe.SetActive(true);
        isSafeOpened = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            isIn = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.CompareTag("Player") && collision.GetComponent<PhotonView>().isMine)
        {
            isIn = false;
            codePanel.SetActive(false);
            UIopen = !UIopen;
        }
    }

    public void activate()
    {
        isActive = true;
    }


}
