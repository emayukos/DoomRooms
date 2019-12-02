using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class projectorPanelUI : MonoBehaviour
{
    [SerializeField]
    private bool isCorrect;

    //InputField field7;
    //InputField field1;
    //InputField field2;
    //InputField field6;
    //InputField field4;
    //InputField field5;

    string field7 = "";
    string field1 = "";
    string field2 = "";
    string field6 = "";
    string field4 = "";
    string field5 = "";


    [SerializeField]
    GameObject fileCabinet;

    public PhotonView photonView;

    public AudioClip incorrectanswer;
    private AudioSource source;

    public string code = "726541";

    public string codeTextVal = "";

    GameObject networkTextBox;

    ////for single player testing
    //public GameObject cabinetOpen;
    //public GameObject cabinetClosed;

    
    // Start is called before the first frame update

    public void Awake()
    {
        //field7 = GameObject.Find("InputField7").GetComponent<InputField>();
        //field1 = GameObject.Find("InputField1").GetComponent<InputField>();
        //field2 = GameObject.Find("InputField2").GetComponent<InputField>();
        //field6 = GameObject.Find("InputField6").GetComponent<InputField>();
        //field4 = GameObject.Find("InputField4").GetComponent<InputField>();
        //field5 = GameObject.Find("InputField5").GetComponent<InputField>();
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
        networkTextBox = GameObject.Find("Network Message Text");

    }

    

    public void onSubmit() {

        Debug.Log("field1 fn: " + field1);
        //Debug.Log("field1 text fn: " + field1);

        //codeTextVal = field7.text + field2.text + field6.text + field5.text + field4.text + field1.text;
        codeTextVal = field7 + field2 + field6 + field5 + field4 + field1;

        if (codeTextVal == code)
        {
            isCorrect = true;
            Debug.Log("correct code");

            //for single player testing
            //cabinetOpen.SetActive(true);
            //cabinetClosed.SetActive(false);


            // for photon
            Debug.Log(photonView);
            this.photonView.RPC("openFileCabinet", PhotonTargets.All);
            networkTextBox.GetComponent<InteractText>().photonView.RPC(
                    "DisplayLook", PhotonTargets.All, "Correct Answer! The filling cabinet has been opened");
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

    public void addField1(string fieldValue)
    {
        field1 = fieldValue;
        Debug.Log("test: " + field1);
    }

    public void addField2(string fieldValue)
    {
        field2 = fieldValue;
    }
    public void addField4(string fieldValue)
    {
        field4 = fieldValue;
    }
    public void addField5(string fieldValue)
    {
        field5 = fieldValue;
    }
    public void addField6(string fieldValue)
    {
        field6 = fieldValue;
    }
    public void addField7(string fieldValue)
    {
        field7 = fieldValue;
    }

}
