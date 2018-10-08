using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D myRigidBody;

	[SerializeField]
	private float accelerationForce = 5;

    [SerializeField]
    private float maxSpeed = 5;

	private float horizontalInput;
	private float verticalInput;

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
        //Calls MoveHorizontal function. 
		MoveHorizontal();

		
        
	}

    void MoveHorizontal()
	{
		myRigidBody.AddForce(Vector2.right * horizontalInput * accelerationForce);

        Vector2 clampedVelocity = myRigidBody.velocity;

        clampedVelocity.x = Mathf.Clamp(myRigidBody.velocity.x, -maxSpeed, maxSpeed);

        myRigidBody.velocity = clampedVelocity;
	}

    

}