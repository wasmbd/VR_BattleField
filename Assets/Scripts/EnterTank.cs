using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class EnterTank : MonoBehaviour
{
   // public Transform sittingPosition; // Assign the SittingPosition Transform here
    public Transform sittingPosition; // Assign the SittingPosition Transform here

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger
        if (other.CompareTag("Player"))
        {
            // Get the XR Origin (assuming it's the parent of the player's collider)
            var xrOrigin = other.GetComponentInParent<XROrigin>();
            if (xrOrigin != null)
            {
                // Move and rotate the XR Origin to the sitting position
                xrOrigin.MoveCameraToWorldLocation(sittingPosition.position);
                xrOrigin.RotateAroundCameraUsingOriginUp(sittingPosition.eulerAngles.y);

                // Parent the tank to the XR Origin
                transform.SetParent(xrOrigin.transform, true);
            }
        }
    }
}
