using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTank : MonoBehaviour
{
    public Transform sittingPosition; // Assign the SittingPosition Transform here
    public Camera tankCamera; // Assign the tank camera here
    private Camera playerCamera;

    private void Start()
    {
        // Find the player's camera
        playerCamera = Camera.main;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")|| other.CompareTag("Tank"))
        {
            // Unparent the tank from the XR Origin
            transform.SetParent(null, true);


            // Switch cameras back
            if (tankCamera != null)
            {
                tankCamera.gameObject.SetActive(false);
            }
            if (playerCamera != null)
            {
                playerCamera.gameObject.SetActive(true);
            }
        }
    }
}
