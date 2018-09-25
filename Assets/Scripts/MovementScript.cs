using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public Rigidbody2D MyRigidBody;

    [SerializeField]
    private int speed;

    [SerializeField]
    private int jumpHeight;

    private float moveInput;

    // Use this for initialization
    void Start()
    {
        Debug.Log("This is start.");

    }

    // Update is called once per frame
    void Update()
    {
        
        Jump();

    }

    private void FixedUpdate()
    {
        
    }

    private void GetMovementInput()
    {
       moveInput = Input.GetAxis("Horizontal");
    }

    //Moves the character left and right.
    void Move()
    {
        //Move with velocity because it is using physics.
        if (Input.GetKey(KeyCode.D))
        {
            //Move Character to the right. 
            MyRigidBody.velocity = new Vector2(speed, MyRigidBody.velocity.y);

        }

        if (Input.GetButton(KeyCode.A))
        {
            //Move Character to the left. 
            MyRigidBody.velocity = new Vector2(-speed, MyRigidBody.velocity.y);

        }

       
    }

    //Moves the character up with each button press.
    void Jump()
    {
        if (Input.GetKeyDown("Jump"))
        {
            //Move Character upwards. 
            MyRigidBody.velocity = new Vector3(0, jumpHeight, MyRigidBody.velocity.x);

        }
    }
  
}
