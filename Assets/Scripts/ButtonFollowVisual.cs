using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class ButtonFollowVisual : MonoBehaviour
{
    public Transform visualTarget; // Target to follow
    public Vector3 localAxis; // Axis of movement
    public float resetSpeed = 5; // Speed to reset position

    private Transform PokeAttachTransform; // Poke interactor's attach point
    private XRBaseInteractable interactable; // Interactable component

    private Vector3 linitialLocalPos; // Initial local position
    private Vector3 offset; // Offset for following

    private bool isFollowing = false; // Flag to follow
    private bool freeze = false; // Flag to freeze

    void Start()
    {
        linitialLocalPos = visualTarget.localPosition; // Store initial position
        interactable = GetComponent<XRBaseInteractable>(); // Get interactable component
        interactable.hoverEntered.AddListener(Follow); // Add hover entered listener
        interactable.hoverExited.AddListener(Reset); // Add hover exited listener
        interactable.selectEntered.AddListener(Freeze); // Add select entered listener
    }
    // Method called when a hover interaction starts
    public void Follow(BaseInteractionEventArgs hover)
    {
        // Check if the interactor is an XRPokeInteractor
        if (hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;
            isFollowing = true; // Set the flag to start following
            PokeAttachTransform = interactor.attachTransform; // Get the poke attach transform
            offset = visualTarget.position - PokeAttachTransform.position; // Calculate the offset
            freeze = false; // Ensure the button is not frozen
        }
    }

    // Method called when a hover interaction ends
    public void Reset(BaseInteractionEventArgs hover)
    {
        // Check if the interactor is an XRPokeInteractor
        if (hover.interactorObject is XRPokeInteractor)
        {
            isFollowing = false; // Set the flag to stop following
            freeze = false; // Ensure the button is not frozen
        }
    }

    // Method called when a select interaction starts
    public void Freeze(BaseInteractionEventArgs hover)
    {
        // Check if the interactor is an XRPokeInteractor
        if (hover.interactorObject is XRPokeInteractor)
        {
            freeze = true; // Set the flag to freeze the button in place
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (freeze) return; // Do nothing if frozen

        if (isFollowing)
        {
            Vector3 localTargetPosition = visualTarget.InverseTransformPoint(PokeAttachTransform.position + offset); // Calculate local target position
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargetPosition, localAxis); // Constrain movement
            visualTarget.position = visualTarget.TransformPoint(constrainedLocalTargetPosition); // Update position
        }
        else
        {
            visualTarget.localPosition = Vector3.Lerp(visualTarget.localPosition, linitialLocalPos, Time.deltaTime * resetSpeed); // Reset position
        }
    }
}
