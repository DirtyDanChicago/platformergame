using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private float inactiveSpeed = 100, activeSpeed = 200;

    [SerializeField]
    private float inactiveScale = 1, activatedScale = 0.5f;

    [SerializeField]
    private Color inactiveColor, activeColor;

    private bool isActivated = false;

    private SpriteRenderer spriteRenderer;

    private AudioSource audioSource;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    //Animates checkpoint.
    private void Update()
    {
        UpdateRotation();
        UpdatedScale();
        UpdatedColor();
       
    }

    //Changes color when activated.
    private void UpdatedColor()
    {
        Color color = inactiveColor;

        if (isActivated)
        {
            color = activeColor;
        }

        spriteRenderer.color = color;
    }

    //Shrinks when activated.
    private void UpdatedScale()
    {
        float scale = inactiveScale;

        if (isActivated)
        {
            scale = activatedScale;
            
        }

        transform.localScale = Vector3.one * scale;
    }

    //Rotates when activated.
    private void UpdateRotation()
    {
        float rotationSpeed = inactiveSpeed;
        if (isActivated)
        {
            rotationSpeed = activeSpeed;
        }

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    public void SetIsActivated(bool value)
    {
        isActivated = value;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActivated)
        {
           
            Debug.Log("Player entered the checkpoint.");

            MovementScript player = collision.GetComponent<MovementScript>();

            player.SetCurrentCheckpoint(this);

            audioSource.Play();
        }
   
    }

}
