using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour  
{

    [SerializeField]
    public KillZone killZone;

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

            player.Respawn();

            audioSource.Play();

            killZone.GhostReset();
        }
        else
        {
            Debug.Log("Something other than the player entered the trigger.");
        }
    }

    
}
