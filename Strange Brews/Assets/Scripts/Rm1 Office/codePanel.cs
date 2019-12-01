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

    

    public PhotonView photonView;

    public AudioClip buttonclick;
    public AudioClip incorrectanswer;
    private AudioSource source;

    private int spot;
    private char[] chararray = { '0', '0', '0', '0' };

	public string code = "3101";

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }



    string codeTextValue = "0000";
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
        Debug.Log("OnClick AddDigit");
        // only add digits if the code is less than 4
        if (spot < 4)
		{
            // the sound effect and the volume (x/1)
            source.PlayOneShot(buttonclick, 1.0f);
            chararray[spot] = digit[0];
            codeTextValue = new string(chararray);
            spot++;
		}
		
	}

    public void pressEnter()
	{
		if (codeTextValue.Equals(code))
		{
            this.photonView.RPC("openSafe", PhotonTargets.All); 
		}
        else
        {
            source.PlayOneShot(incorrectanswer, 0.5f);
            codeTextValue = "0000";

            for (int i=0;i<4;i++) chararray[i] = '0';
            
            spot = 0;
        }
	}


}
