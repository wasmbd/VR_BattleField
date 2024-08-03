using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    [SerializeField] float moveRange = 2f; // The maximum distance the object will move up and down
    [SerializeField] float moveSpeed = 2f; // The speed at which the object moves

    private Vector3 initialPosition;
    private bool movingUp = true;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        MoveUpDown();
    }

    private void MoveUpDown()
    {
        Vector3 targetPosition;
        if (movingUp)
        {
            targetPosition = initialPosition + Vector3.up * moveRange;
        }
        else
        {
            targetPosition = initialPosition + Vector3.down * moveRange;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            movingUp = !movingUp;
        }
    }
}


