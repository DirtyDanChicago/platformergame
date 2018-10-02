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
		verticalInput = Input.GetAxis("Vertical");
	}

	//Fixed update for movement.
	void FixedUpdate()
	{

		MoveHorizontal();

		//MoveVertical();
        
	}

    void MoveHorizontal()
	{
		myRigidBody.AddForce(Vector2.right * horizontalInput * speed);
	}

    /*void MoveVertical()
	{
		myRigidBody.AddForce(Vector2.right * verticalInput * speed);
	}
    */


}