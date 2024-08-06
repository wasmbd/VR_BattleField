using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HelicopterController : MonoBehaviour
{
    public float moveStep = 1f;

    // Method to move the plane up
    public void MoveUp()
    {
        transform.position += Vector3.up * moveStep;
    }

    public void MoveDown()
    {
        transform.position += Vector3.down * moveStep;
    }
}
