﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    void OnTriggerEnter2D(Collider2D collision)
    {

        //Goes to next level when player hits door.
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);

            Debug.Log("Player escaped.");

            Collectable.peopleCount = 0;
        }
    }

}
