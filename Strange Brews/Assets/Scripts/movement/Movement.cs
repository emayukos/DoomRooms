using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : Photon.MonoBehaviour
{
    public bool devTesting;

    /*
     * this takes all the values (transform, position, etc.)
     * and passes it across the network
     */
    public PhotonView photoView; // thomas changed this variable name when debugging

    private Vector3 selfPosition;

    private Vector3 selfScale;

	private Animator selfAnim;

    private float velocity;

    private float characterscale;

    private Rigidbody2D rbody;

    private Vector2 position;

    private float initial_y;
    
    // variables from other scripts
    public float moveSpeed = 4f;
    
    // Animation Variables
    Animator thisAnim;
    float lastX, lastY;

	bool movement;
	float selfx;
	float selfy;

	//private GameObject mainCam;
	//public GameObject plCam;

	//private photonHandler avatarSetup;

	//public bool UseTransformView = true;





	//private void Awake()
	//{
	//	if(!devTesting && photonView.isMine)
	//	{
	//		//mainCam = GameObject.Find("Main Camera");
	//		//mainCam.SetActive(false);
	//		//plCam.SetActive(true);
			
	//	}
	//}



	// Start is called before the first frame update
	void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        velocity = 5.0f;
        position = rbody.position;
        initial_y = position.y;
        thisAnim = GetComponent<Animator>();
		//avatarSetup = GetComponent<photonHandler>();

    }


	// FixedUpdate is called at a fixed rate, while Update is simply called for every rendered frame
	// FixedUpdate should be used to write the code related to the physics simulation (e.g. applying force, setting velocity and so on)
	void FixedUpdate()
    {

        if (!devTesting)
        {
            /* this makes sure it only moves the one player */
            if (photoView.isMine)
            {
                moveCharacter();
            }
            else
            {
                smoothNetMovement();
    
            }
        }
        else
        {
            moveCharacter();
        }


    }

    //private void moveCharacter()
    //{
    //    float h = Input.GetAxis("Horizontal");
    //    float v = Input.GetAxis("Vertical");

    //    rbody.velocity = new Vector2(velocity * h, velocity * v);

    //    //characterscale = (transform.position.y - (transform.position.y - initial_y) * 0.5f) / initial_y;

    //    //transform.localScale = new Vector3(characterscale, characterscale, characterscale);
        
    //    Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        
    //    //UpdateAnimation(heading);
    //}
    void moveCharacter()
    {
        Vector3 rightMovement = Vector3.right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = Vector3.up * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.position += rightMovement;
        transform.position += upMovement;
		
        UpdateAnimation(heading);
    }

    private void smoothNetMovement()
    {
		//if (UseTransformView)
			//return; // this will take care of what the code below did before
    	
        transform.position = Vector3.Lerp(transform.position, selfPosition, Time.deltaTime * 8);
        //transform.localScale = Vector3.Lerp(transform.localScale, selfScale, Time.deltaTime * 8);
    }
    
    


    void UpdateAnimation(Vector3 dir)
    {
  	
        if(dir.x == 0f && dir.y == 0f)
        {
			movement = false;
            thisAnim.SetFloat("Last_DirectionX", lastX);
            thisAnim.SetFloat("Last_DirectionY", lastY);
            thisAnim.SetBool("Movement", movement);

        }
        else
        {
			movement = true;
            lastX = dir.x;
            lastY = dir.y;
            thisAnim.SetBool("Movement", movement);

        }

		selfx = dir.x;
		selfy = dir.y;

        thisAnim.SetFloat("DirX", selfx);
        thisAnim.SetFloat("DirY", selfy);
        //myThirdPersonController myC= GetComponent<myThirdPersonController>();
    }



    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // if it is the local player it streams the positions and other things
        
   //     if (UseTransformView)
			//return; // this will take care of what the code below did before
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            //stream.SendNext(transform.localScale);
			stream.SendNext(thisAnim.GetBool("Movement"));
			stream.SendNext(thisAnim.GetFloat("Last_DirectionX"));
			stream.SendNext(thisAnim.GetFloat("Last_DirectionY"));
			stream.SendNext(thisAnim.GetFloat("DirX"));
			stream.SendNext(thisAnim.GetFloat("DirY"));
			//stream.SendNext(myC._characterState); // int?
			
			
			
        }
        else
        {
            selfPosition = (Vector3)stream.ReceiveNext();
			//selfScale = (Vector3)stream.ReceiveNext();
			movement = (bool)stream.ReceiveNext();
			lastX = (float)stream.ReceiveNext();
			lastY = (float)stream.ReceiveNext();
			selfx = (float)stream.ReceiveNext();
			selfy = (float)stream.ReceiveNext();
			//thisAnim.state = (int)stream.ReceiveNext();
		
			//myC._characterState = (CharacterState)stream.ReceiveNext();
			//myC._characterState = (int)stream.ReceiveNext();
			
			

            
            

        }
    }


}

