﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered the checkpoint.");

            MovementScript player = collision.GetComponent<MovementScript>();

            player.SetCurrentCheckpoint(this);
        }
   
    }

}
