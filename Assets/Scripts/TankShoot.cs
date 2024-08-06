
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TankShoot : MonoBehaviour
{
    public ParticleSystem shootEffect; // Assign the shooting particle system prefab here
    public AudioClip shootSound; // Assign the shooting sound here
    public Transform shootPoint; // Assign the shooting point here

    private AudioSource audioSource;
    private InputDevice rightController;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();



        // Find the right controller
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            rightController = devices[0];
        }
    }




    void Update()
    {
        if (rightController.isValid)
        {
            if (rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed) && isPressed)
            {
                Shoot();
            }
        }
        else
        {
            Debug.LogWarning("Right controller is not valid");
        }
    }

    private void Shoot()
    {
        // Play the shooting particle effect at the shoot point
        if (shootEffect != null && shootPoint != null)
        {
            ParticleSystem ps = Instantiate(shootEffect, shootPoint.position, shootPoint.rotation);
            ps.Play();
            Destroy(ps.gameObject, ps.main.duration);
        }

        // Play the shooting sound
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }
}
