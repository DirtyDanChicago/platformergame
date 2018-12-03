using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField]
    private float zoneSpeed = 10f;

    private void FixedUpdate()
    {
        transform.Translate(zoneSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovementScript player = collision.GetComponent<MovementScript>();

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger.");

            player.Respawn();

        }
        else
        {
            Debug.Log("Something other than the player entered the trigger.");
        }
    }


}

