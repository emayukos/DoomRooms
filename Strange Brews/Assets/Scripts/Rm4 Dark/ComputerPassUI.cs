using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPassUI : MonoBehaviour
{
    [SerializeField]
    private bool isCorrect;

    string field1 = "";

    public PhotonView photonView;

    public AudioClip incorrectanswer;
    private AudioSource source;

    public string code = "111795";


    ////for single player testing
    //public GameObject cabinetOpen;
    //public GameObject cabinetClosed;


    public void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {

        Debug.Log("field1: " + field1);
        Debug.Log("source: " + source);

        //cabinetClosed.SetActive(true);
        //cabinetOpen.SetActive(false);
        gameObject.SetActive(false);
        Debug.Log(photonView);

    }



    public void onSubmit()
    {

        Debug.Log("field1 fn: " + field1);

        if (field1 == code)
        {
            isCorrect = true;
            Debug.Log("correct code");

            //for single player testing
            //cabinetOpen.SetActive(true);
            //cabinetClosed.SetActive(false);


            // for photon
            Debug.Log(photonView);
            this.photonView.RPC("openComputer", PhotonTargets.All);

        }
        else
        {
            //FIX SOUND THING
            source.PlayOneShot(incorrectanswer, 0.5f);
            Debug.Log("wrong code");
        }

    }

    //private void closePanel()
    //{
    //    gameObject.SetActive(false);
    //}

    public void addFieldValue(string fieldValue)
    {
        field1 = fieldValue;
        Debug.Log("test: " + field1);
    }

}

