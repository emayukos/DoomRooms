using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowPlayerInfo : Photon.MonoBehaviour
{
	// on the character
	//[SerializedField]
	public Text mTextOverHead;
	private Vector2 textPos;
	//private Vector2 mTextOverPos;

	void Awake() {
		textPos = transform.position;
		mTextOverHead.text = "Hi";
	}
	void LateUpdate() {

		// add a tiny bit of height?
		textPos.y += 10; // adjust as you see fit.
		mTextOverHead.transform.position = textPos;
	}
}
		
		
		
//    private Canvas textGo;
//    private TextMesh tm;
//    public bool DisableOnOwnObjects;

//    void Start()
//    {
//        if (tm == null) //wenn textmesh
//        {	
//            textGo =  GetComponentInChildren<Canvas>();
//			tm = textGo.GetComponent<TextMesh>;
            
//        }
//    }

//    void Update()
//    {
//        bool showInfo = !this.DisableOnOwnObjects || this.photonView.isMine;
//        if (tm != null)
//        {
//            tm.SetActive(showInfo);
//        }
//        if (!showInfo)
//        {
//            return;
//        }
//        PhotonPlayer owner = this.photonView.owner;
//        if (owner != null)
//        {
//            tm.text = (string.IsNullOrEmpty(owner.NickName)) ? "player" + owner.ID : owner.NickName;
//        }
//        else if (this.photonView.isSceneView)
//        {
//            tm.text = "scn";
//        }
//        else
//        {
//            tm.text = "n/a";
//        }
//    }

