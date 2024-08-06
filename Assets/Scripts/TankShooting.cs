using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TankShooting : MonoBehaviour
{
    public ParticleSystem shootEffect; // Assign the shooting particle system prefab here
    public AudioClip shootSound; // Assign the shooting sound here
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Ensure AudioSource is added
    }

    public void OnPoke()
    {
        Shoot();
    }
    private void Shoot()
    {
        // Play the shooting particle effect
        if (shootEffect != null)
        {
            shootEffect.Play();
        }

        // Play the shooting sound
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }
}
