using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowPlayerInfo : Photon.MonoBehaviour

{
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
}
