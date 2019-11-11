using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class codePanel : MonoBehaviour
{
	[SerializeField]
	TextMeshProUGUI codeText;

    [SerializeField]
	GameObject safe;

	public string code = "3101";


	string codeTextValue = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		codeText.text = codeTextValue;
        
    }

    public void AddDigit(string digit)
	{
        // only add digits if the code is less than 4
        if (codeTextValue.Length < 4)
		{
			codeTextValue += digit;
		}
		
	}

    public void pressEnter()
	{
		if (codeTextValue.Equals(code))
		{
			safe.SendMessage("openSafe");
		}
        else
        {
            // maybe play error sound effect
            // make it say error for 2 seconds
            codeTextValue = "";
        }
	}
}
