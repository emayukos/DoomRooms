using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPassUI : MonoBehaviour
{
    [SerializeField]
    private bool isCorrect;

    string field1 = "";

    public PhotonView photonView;   //photonView of object with ComputerScreen script, not UI, to set visible screen and associated active objects

    public AudioClip incorrectanswer;
    private AudioSource source;

    public string code = "111795";  //first draft code for bottom room computer, changed for each in Inspector


    public void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        Debug.Log("field1: " + field1);
        Debug.Log("source: " + source);

        //computer not visible until interacted with
        gameObject.SetActive(false);
        Debug.Log(photonView);
    }



    public void onSubmit()
    {
        //for submit Button component

        Debug.Log("field1 fn: " + field1);

        if (field1 == code)
        {
            isCorrect = true;
            Debug.Log("correct code");

            // for photon
            //Debug.Log(photonView);
            this.photonView.RPC("openComputer", PhotonTargets.All);
        }
        else
        {
            source.PlayOneShot(incorrectanswer, 0.5f);
            Debug.Log("wrong code");
        }
    }


    public void addFieldValue(string fieldValue)
    {
        //for Input Field component
        field1 = fieldValue;
        Debug.Log("test: " + field1);
    }

}

