using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private AudioSource pickUp;
    private SpriteRenderer carrot;
    private BoxCollider2D carrotCollider;
    private static int carrotCount = 0;

    private void Start()
    {
        pickUp = GetComponent<AudioSource>();
        carrot = GetComponent<SpriteRenderer>();
        carrotCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            carrotCount++;
            Debug.Log("Carrots Collected: " + carrotCount);

            pickUp.Play();

            carrotCollider.enabled = false;
            carrot.enabled = false;
            
            Destroy(gameObject, pickUp.clip.length);
            
        }
    }
}
