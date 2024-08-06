using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class EnterTank : MonoBehaviour
{

    public Transform sittingPosition;
    public Camera tankCamera;
    private Camera playerCamera;
    public GameObject UI;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the XR Origin (assuming it's the parent of the player's collider)
            var xrOrigin = other.GetComponentInParent<XROrigin>();
            if (xrOrigin != null)
            {
                // Move and rotate the XR Origin to the sitting position
                xrOrigin.MoveCameraToWorldLocation(sittingPosition.position);
                //xrOrigin.RotateAroundCameraUsingOriginUp(sittingPosition.eulerAngles.y);
                UI.SetActive(true);
                EndUI();
                // Parent the tank to the XR Origin
                transform.SetParent(xrOrigin.transform, true);

                // Switch cameras
                if (playerCamera != null)
                {
                    playerCamera.gameObject.SetActive(false);
                }
                if (tankCamera != null)
                {
                    tankCamera.gameObject.SetActive(true);
                }
            }
        }
    }
    IEnumerator EndUI()
    {
        if(UI.gameObject.tag == "Finish")
        {
            yield return new WaitForSeconds(3f);
            UI.gameObject.SetActive(false);
        }
       
    }
    /* private void OnTriggerExit(Collider other)
     {
         if (other.CompareTag("Player") || other.CompareTag("Tank"))
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
     }*/
}
