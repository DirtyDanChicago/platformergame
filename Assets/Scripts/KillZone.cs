using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovementScript player = collision.GetComponent<MovementScript>();

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger.");

            player.Injury();


        }
        else
        {
            Debug.Log("Something other than the player entered the trigger.");
        }
    }


}

