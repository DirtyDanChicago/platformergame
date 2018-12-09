using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField]
    private float zoneSpeed = 10f;
    public static Vector3 originalPos;

    private AudioSource audioSource;


    public void Start()
    {
        //Gets the ghost's original position.
        KillZone.originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        audioSource = GetComponent<AudioSource>();

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

            player.Death();

            audioSource.Play();

            GhostReset();

        }
        else
        {
            Debug.Log("Something other than the player entered the trigger.");
        }
    }

    public void GhostReset()
    {
        //Resets ghost position on player death.
        gameObject.transform.position = originalPos;

        transform.Translate(zoneSpeed * Time.deltaTime, 0, 0);

    }


}

