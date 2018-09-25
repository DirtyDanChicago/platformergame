using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

    public Rigidbody2D MyRigidBody;

    [SerializeField]
    private int speed;
   

    // Use this for initialization
	void Start ()
    {
        Debug.Log("This is start.");

	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey(KeyCode.D))
        {
            //Move Character to the right. 
            MyRigidBody.velocity = new Vector2(speed, MyRigidBody.velocity.y);

        }

        if (Input.GetKey(KeyCode.A))
        {
            //Move Character to the left. 
            MyRigidBody.velocity = new Vector2(-speed, MyRigidBody.velocity.y);

        }

        if (Input.GetKey(KeyCode.W))
        {
            //Move Character upwards. 
            MyRigidBody.velocity = new Vector3(0,10, MyRigidBody.velocity.x);

        }


    }
}
