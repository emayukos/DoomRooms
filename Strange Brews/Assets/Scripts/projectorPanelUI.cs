using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectorPanelUI : MonoBehaviour
{
    [SerializeField]
    private bool isCorrect;
    public PhotonView phtonView;
    Input field7;
    Input field1;
    Input field2;
    Input field6;
    Input field4;
    Input field5;

    public string code = "726541";

    public string codeTextVal = "";

    private GameObject projectorBackground;
    // Start is called before the first frame update

    public void Awake()
    {
        field7 = GameObject.Find("InputField7").GetComponent<Input>();
        field1 = GameObject.Find("InputField1").GetComponent<Input>();
        field2 = GameObject.Find("InputField2").GetComponent<Input>();
        field6 = GameObject.Find("InputField6").GetComponent<Input>();
        field4 = GameObject.Find("InputField4").GetComponent<Input>();
        field5 = GameObject.Find("InputField5").GetComponent<Input>();
    }

    public void Update()
    {
        
    }
    public bool onSubmit() {

        codeTextVal = field7.ToString() + field2.ToString() + field6.ToString() + field5.ToString() + field4.ToString() + field1.ToString();

        Debug.Log(codeTextVal);
        return true;
    }
}
