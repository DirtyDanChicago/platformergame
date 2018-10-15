using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private float inactiveSpeed = 100, activeSpeed = 200;

    private bool isActivated = false;

    private void Update()
    {
        UpdateRotation();
    }

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
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered the checkpoint.");

            MovementScript player = collision.GetComponent<MovementScript>();

            player.SetCurrentCheckpoint(this);
        }
   
    }

}
