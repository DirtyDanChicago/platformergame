﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//Daniel Dababneh Platformer Game

//Thanks to Ami Patel for the death animation assistance.

public class MovementScript : MonoBehaviour
{
    //Rigid body variable. 
	[SerializeField]
	private Rigidbody2D myRigidBody;

    //Jump's force.
    [SerializeField]
    private float jumpForce = 10;

    //Acceleration variable.
    [SerializeField]
	private float accelerationForce = 5;

    //Max speed variable.
    [SerializeField]
    private float maxSpeed = 5;

    //Player ground collider.
    [SerializeField]
    private Collider2D playerGroundCollider;

    //Moving, and stopped physics materials.
    [SerializeField]
    private PhysicsMaterial2D playerMovingPhysicsMaterial, playerStoppingPhysicsMaterial;

    //Ground detection.
    [SerializeField]
    private Collider2D groundDetectTrigger;

    //Ground detection filters.
    [SerializeField]
    private ContactFilter2D groundContactFilter;


    //Text letting you know to move on.
    public Text winText;

    //Counts how many people you've saved.
    public Text peopleCountText;

    public Text deathText;

    //Ground detection results.
    private Collider2D[] groundHitDetectionResults = new Collider2D[16];

    //Animator.
    private Animator myAnimator;

    //Ground detect variable.
    private bool isOnGround;

    //Direction variable.
    private bool facingRight = true;

    //Horizontal, and vertical input variables.
	private float horizontalInput;

    //Keeps track of checkpoint
    private Checkpoint currentCheckpoint;

    //Death Audio
    private AudioSource audioSource;

    //Calls wagon object.
    private GameObject wagon;

    private bool isDead;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();

        wagon = GameObject.FindGameObjectWithTag("Wagon");

        wagon.gameObject.SetActive(false);

        winText.gameObject.SetActive(false);

        deathText.gameObject.SetActive(false);

        myAnimator.SetBool("hurt", false);
    }

    private void Update()
    {
        //Stops the rotation.
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.z = 0;
        transform.localEulerAngles = currentRotation;

        //On Ground Update.
        UpdateIsOnGround();

        //Horizontal Movement Function.
        UpdateHorizontalMovement();

        //Jump Input Function.
        HandleJumpInput();

        CheckForRespawn();

        peopleCountText.text = "People Saved: " + Collectable.peopleCount;

        OpenExit();
    }

	//Fixed update for movement.
	void FixedUpdate()
	{
        UpdatePhysicsMaterial();

        //Calls Move function.
        Move();

        UpdateFlip();
        

    }

    //Changes physics material whether or not the player is moving or staying still.
    private void UpdatePhysicsMaterial()
    {
        if (Mathf.Abs(horizontalInput) > 0)
        {
            playerGroundCollider.sharedMaterial = playerMovingPhysicsMaterial;
        }

        else
        {
            playerGroundCollider.sharedMaterial = playerStoppingPhysicsMaterial;
        }
    }

    //Mirrors the character based on movement direction.
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //Provides function for Update.
    private void UpdateFlip()
    {
        if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && facingRight)
        {
            Flip();
        }
    }
    
    //Checks if the player is on the ground.
    private void UpdateIsOnGround()
    {
        isOnGround = groundDetectTrigger.OverlapCollider(groundContactFilter, groundHitDetectionResults) > 0;

        //Debug.Log("Is On Ground?: " + isOnGround);

        //Changes from run to jump if in the air.
        if(isOnGround == true)
        {
            myAnimator.SetBool("onground", true);
        }
        else
        {
            myAnimator.SetBool("onground", false);
        }
    }

    //Gets horizontal movement input.
    private void UpdateHorizontalMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    
    }

    //Movement function.
    private void Move()
	{
		myRigidBody.AddForce(Vector2.right * horizontalInput * accelerationForce);

        Vector2 clampedVelocity = myRigidBody.velocity;

        clampedVelocity.x = Mathf.Clamp(myRigidBody.velocity.x, -maxSpeed, maxSpeed);

        myRigidBody.velocity = clampedVelocity;

        myAnimator.SetFloat("speed", Mathf.Abs(horizontalInput));

    }


    //Jump function.
    private void HandleJumpInput()
    {
        
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            myRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
      
    }

    //Player is dead state.
    public void Death()
    {
        isDead = true;
        myAnimator.SetBool("hurt", true);
        deathText.gameObject.SetActive(true);
       
    }

    //Checks for players respawn input. R is respawn.
    public void CheckForRespawn()
    {
        if (isDead)
        {
            myRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;

            if (Input.GetButtonDown("Respawn"))
            {
                Respawn();

                deathText.enabled = false;
            }
        }
    }

    //Respawns player.
    public void Respawn()
    {

        //Checks for respawn point.
        if (currentCheckpoint == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            Debug.Log("The player died and respawed.");

            myAnimator.SetBool("hurt", false);
        }
        else
        {
            myRigidBody.velocity = Vector2.zero;
            transform.position = currentCheckpoint.transform.position;

            myAnimator.SetBool("hurt", false);
        }
       
    }

    //Sets player's spawnpoint.
    public void SetCurrentCheckpoint(Checkpoint newCurrentCheckpoint)
    {
        if (currentCheckpoint != null)
            currentCheckpoint.SetIsActivated(false);

        currentCheckpoint = newCurrentCheckpoint;
        currentCheckpoint.SetIsActivated(true);
    }

    //Activates the wagon on win condition.
    private void OpenExit()
    {
        if (Collectable.peopleCount >= 2)
        {
            wagon.gameObject.SetActive(true);

            winText.gameObject.SetActive(true);
            
        }
            
    }

}