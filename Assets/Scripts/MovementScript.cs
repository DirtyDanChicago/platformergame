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

    // Use this for initialization
    void Start()
    {
        Debug.Log("This is start.");

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

    }

    void Move()
    {
        //Move with velocity because it is using physics.
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

       
    }

    // TODO: Make this jump a little, not forever.
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Move Character upwards. 
            MyRigidBody.velocity = new Vector3(0, jumpHeight, MyRigidBody.velocity.x);

        }
    }
  
}
