using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GunShooting : MonoBehaviour
{

    public GameObject bulletPrefab; // Assign the bullet prefab here
    public Transform bulletSpawn; // Assign the empty GameObject for bullet spawn position here
    public float bulletSpeed = 1000f;
    public float shootRate = 0.5f;
    public AudioClip shootSound; // Assign the shooting sound here

    private float lastShootTime;
    private XRGrabInteractable grabInteractable;
    private XRController controller;
    private AudioSource audioSource;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);

        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        controller = interactor.GetComponent<XRController>();
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        controller = null;
    }

    void Update()
    {
        // Check if the controller is valid and the index button is pressed
        if (controller != null && controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed) && isPressed && Time.time > lastShootTime + shootRate)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        lastShootTime = Time.time;

        // Instantiate the bullet at the bullet spawn position
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Add force to the bullet to make it move
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletSpawn.forward * bulletSpeed);

        // Play the shooting sound
        audioSource.PlayOneShot(shootSound);

        // Destroy the bullet after 2 seconds to avoid memory leaks
        Destroy(bullet, 2.0f);
    }
}
