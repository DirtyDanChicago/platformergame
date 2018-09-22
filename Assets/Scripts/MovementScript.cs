using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

    public Rigidbody2D MyRigidBody;
 

	// Use this for initialization
	void Start ()
    {
        Debug.Log("This is start.");
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log("What's up fuckers?");

        if (Input.GetKey(KeyCode.D))
        {
            //Move Character to the right. 
            MyRigidBody.velocity = new Vector2(5, MyRigidBody.velocity.y);

        }

        if (Input.GetKey(KeyCode.W))
        {
            //Move Character to the right. 
            MyRigidBody.velocity = new Vector2(5, MyRigidBody.velocity.y);

        }
    }
}
