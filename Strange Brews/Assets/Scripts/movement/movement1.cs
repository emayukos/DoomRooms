using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float velocity=7;      //speed factor used for velocity-based movement

    private Rigidbody2D rbody;

    // Start is called before the first frame update 
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Simple velocity-based movement
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        rbody.velocity = new Vector2(velocity*h, velocity*v);
    }
}
