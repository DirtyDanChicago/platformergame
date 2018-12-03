using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private AudioSource pickUp;
    private SpriteRenderer people;
    private BoxCollider2D peopleCollider;
    private static int peopleCount = 0;

    private GameObject wagon;

    private void Start()
    {
        pickUp = GetComponent<AudioSource>();
        people = GetComponent<SpriteRenderer>();
        peopleCollider = GetComponent<BoxCollider2D>();

        wagon = GameObject.FindGameObjectWithTag("Wagon");

        wagon.SetActive(false);
    }

    private void OpenExit()
    {
        if (peopleCount >= 2)
        {
            wagon.SetActive(true);

            Debug.Log("The wagon is here, run!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PeopleDetect"))
        {
            peopleCount++;
            Debug.Log("People Saved: " + peopleCount);

            pickUp.Play();

            peopleCollider.enabled = false;
            people.enabled = false;
            
            Destroy(gameObject, pickUp.clip.length);
            
        }
    }
}
