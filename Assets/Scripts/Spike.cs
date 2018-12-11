using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour  
{

    [SerializeField]
    private KillZone killZone;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovementScript player = collision.GetComponent<MovementScript>();

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger.");

            killZone.GhostReset();

            player.Death();

            audioSource.Play();
            
        }
        else
        {
            Debug.Log("Something other than the player entered the trigger.");
        }
    }

}
