using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HelicopterController : MonoBehaviour
{
    public GameObject Helicopter;
    public Transform maxflyPoint;

    public AnimationClip AnimationClip;
    public AudioClip flySound; // Assign the flying sound here
    private AudioSource flysound;
    private Animator animator;

    void Start()
    {
        flysound = Helicopter.GetComponent<AudioSource>();
        animator = Helicopter.GetComponent<Animator>();

        if (flysound == null)
        {
            flysound = Helicopter.AddComponent<AudioSource>();
        }

        flysound.clip = flySound;
    }

    public void OnPoke()
    {
        Fly();
    }

    private void Fly()
    {
        // Move the helicopter to the maxflyPoint position
        Helicopter.transform.position = maxflyPoint.position;

        // Play the animation clip
        if (animator != null && AnimationClip != null)
        {
            animator.Play(AnimationClip.name);
        }

        // Play the fly sound
        if (flysound != null)
        {
            flysound.Play();
        }
    }
}
