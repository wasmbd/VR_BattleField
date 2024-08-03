using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject objectToSpawn; // The prefab to instantiate
    private  float spawnInterval = 4.0f; // Time interval between spawns in seconds
    public Transform spawnLocation; // The location where the objects will be spawned

    private float timeSinceLastSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawn = 0f;

        if (spawnLocation == null)
        {
            // Default to the position of the GameObject this script is attached to if no spawn location is specified
            spawnLocation = transform;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObject();
            timeSinceLastSpawn = 0f; // Reset the timer
        }
    }

    void SpawnObject()
    {
        // Instantiate the object at the specified location and rotation
        Instantiate(objectToSpawn, spawnLocation.position, spawnLocation.rotation);
    }
}
