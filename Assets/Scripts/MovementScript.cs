using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D myRigidBody;

	[SerializeField]
	private float speed = 5;

	private float horizontalInput;

	// Use this for initialization
	void Start()
	{
		Debug.Log("Game start successful.");

	}

	private void Update()
	{
		//Gathers horizontal movement.
		horizontalInput = Input.GetAxis("Horizontal");
	}

	//Fixed update for movement.
	void FixedUpdate()
	{

        //Applies horizontal movement.
		myRigidBody.AddForce(Vector2.right * horizontalInput * speed);
        
	}

}