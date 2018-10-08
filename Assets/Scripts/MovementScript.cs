using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    //Rigid body variable. 
	[SerializeField]
	private Rigidbody2D myRigidBody;

    [SerializeField]
    private float jumpForce = 10;

    //Acceleration variable.
    [SerializeField]
	private float accelerationForce = 5;

    //Max speed variable.
    [SerializeField]
    private float maxSpeed = 5;

    [SerializeField]
    private ContactFilter2D groundContactFilter;

    [SerializeField]
    private Collider2D groundDetectTrigger;

    private Collider2D[] groundHitDetectionResults = new Collider2D[16];

    private bool isOnGround;

    //Horizontal, and vertical input variables.
	private float horizontalInput;

	private void Update()
	{
        //On Ground Update.
        UpdateIsOnGround();

        //Horizontal Movement Function.
        UpdateHorizontalMovement();

        //Jump Input Function.
        HandleJumpInput();
	}

	//Fixed update for movement.
	void FixedUpdate()
	{
        //Calls Move function.
        Move();
	     
	}

    private void UpdateIsOnGround()
    {
        isOnGround = groundDetectTrigger.OverlapCollider(groundContactFilter, groundHitDetectionResults) > 0;

        //Debug.Log("Is On Ground?: " + isOnGround);
    }


    private void UpdateHorizontalMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    //Movement function.
    private void Move()
	{
		myRigidBody.AddForce(Vector2.right * horizontalInput * accelerationForce);

        Vector2 clampedVelocity = myRigidBody.velocity;

        clampedVelocity.x = Mathf.Clamp(myRigidBody.velocity.x, -maxSpeed, maxSpeed);

        myRigidBody.velocity = clampedVelocity;
	}


    //Jump function.
    private void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            myRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

}