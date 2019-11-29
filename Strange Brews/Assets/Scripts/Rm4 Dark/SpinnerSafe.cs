using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerSafe : MonoBehaviour
{
    [SerializeField]
    GameObject codePanel, closedSafe, openedSafe;


    public bool isSafeOpened = false; // should not initially be open
    private bool UIopen = false;
    private bool inRange = false;

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
        if (inRange && Input.GetKeyDown(KeyCode.E) && !isSafeOpened)
        {

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
        codePanel.SetActive(false);
        closedSafe.SetActive(false);
        openedSafe.SetActive(true);
        isSafeOpened = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<PhotonView>().isMine)
            {
                inRange = true;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<PhotonView>().isMine)
            {
                inRange = false;
                codePanel.SetActive(false);
                UIopen = !UIopen;
            }

        }
    }

}
