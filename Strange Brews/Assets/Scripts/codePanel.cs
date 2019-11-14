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

    public AudioClip buttonclick;
    public AudioClip incorrectanswer;
    private AudioSource source;

	public string code = "3101";

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }



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
            // the sound effect and the volume (x/1)
            source.PlayOneShot(buttonclick, 1.0f);
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
            source.PlayOneShot(incorrectanswer, 0.5f);
            codeTextValue = "";
        }
	}
}
