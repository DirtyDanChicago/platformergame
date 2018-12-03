using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField]
    private float zoneSpeed = 10f;
    public static Vector3 originalPos;

    public void Start()
    {
        //Gets the ghost's original position.
        KillZone.originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    private void FixedUpdate()
    {
        //Moves the ghost.
        transform.Translate(zoneSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovementScript player = collision.GetComponent<MovementScript>();

      
        //Checks for colliion with player to kill them.
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger.");

            player.Respawn();

            Reset();

        }
        else
        {
            Debug.Log("Something other than the player entered the trigger.");
        }
    }

    private void Reset()
    {
        //Resets ghost position on player death.
        gameObject.transform.position = originalPos;

    }


}

