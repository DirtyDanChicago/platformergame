using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private bool isPlayerInTrigger = false;

    //Can't use this, triggers door twice.
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("DoorLook") && Input.GetButtonDown("Activate"))
    //    {
    //
    //        Debug.Log("Player activated door.");
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Activate") && isPlayerInTrigger)
        {
            Debug.Log("Player activated door.");

            SceneManager.LoadScene("Level 2");

        }
    }

}
