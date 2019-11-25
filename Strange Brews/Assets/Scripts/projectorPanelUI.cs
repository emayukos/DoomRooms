using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class projectorPanelUI : MonoBehaviour
{
    [SerializeField]
    private bool isCorrect;
    InputField field7;
    InputField field1;
    InputField field2;
    InputField field6;
    InputField field4;
    InputField field5;

    [SerializeField]
    GameObject fileCabinet;

    public PhotonView photonView;

    public AudioClip incorrectanswer;
    private AudioSource source;

    public string code = "726541";

    public string codeTextVal = "";

    ////for single player testing
    //public GameObject cabinetOpen;
    //public GameObject cabinetClosed;

    
    // Start is called before the first frame update

    public void Awake()
    {
        field7 = GameObject.Find("InputField7").GetComponent<InputField>();
        field1 = GameObject.Find("InputField1").GetComponent<InputField>();
        field2 = GameObject.Find("InputField2").GetComponent<InputField>();
        field6 = GameObject.Find("InputField6").GetComponent<InputField>();
        field4 = GameObject.Find("InputField4").GetComponent<InputField>();
        field5 = GameObject.Find("InputField5").GetComponent<InputField>();
        source = GetComponent<AudioSource>();


    }

    void Start()
    {
        //cabinetClosed.SetActive(true);
        //cabinetOpen.SetActive(false);
        gameObject.SetActive(false);
        Debug.Log(photonView);

    }

    public void onSubmit() {

        codeTextVal = field7.text + field2.text + field6.text + field5.text + field4.text + field1.text;
        
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

        }
        else
        {
            source.PlayOneShot(incorrectanswer, 0.5f);
            Debug.Log("wrong code");
        }

    }

    //private void closePanel()
    //{
    //    gameObject.SetActive(false);
    //}


}
