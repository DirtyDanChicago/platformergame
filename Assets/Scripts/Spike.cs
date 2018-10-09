using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger.");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            MovementScript player = collision.GetComponent<MovementScript>();

            player.Respawn();
        }
        else
        {
            Debug.Log("Something other than the player entered the trigger.");
        }
    }
}
