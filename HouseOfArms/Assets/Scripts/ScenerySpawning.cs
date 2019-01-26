using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenerySpawning : MonoBehaviour
{
    // This will hold the prefabs we will instantiate during runtime
    public GameObject[] sceneryPrefabs = new GameObject[3];

    public float minTimeBetweenObjects;
    public float maxTimeBetweenObjects;

    // If we want to mirror objects on one side of the road, we set this to true
    public bool isMirrored;

    public float minimumGap;
    public float maximumGap;

    void Start()
    {
        //StartCoroutine (SpawnObjects());
        //Instantiate(sceneryPrefabs[0], this.transform.position, Quaternion.identity, this.transform);

        // Get the z difference from the camera to this transform.
        // Instantiate objects to fill that distance.
        // Random gaps?
        
        float start_z = transform.position.z;
        float end_z   = GameObject.FindGameObjectWithTag("MainCamera").transform.position.z;

        // We will instantiate objects all the way from the start to the end.
        float totalDifference = start_z - end_z;

        float remainingDifference = totalDifference;
        while (remainingDifference > 0)
        {
            Vector3 spawnLocation = new Vector3(transform.position.x, transform.position.y, end_z + remainingDifference);

            Quaternion rotation;
            if (isMirrored == false)
            {
                rotation = Quaternion.identity;
            }
            else
            {
                rotation = Quaternion.Euler(0f, 180f, 0f);
            }

            // Get a random index corresponding to our array of sceneryPrefabs
            int typeOfScenery = Random.Range(0, sceneryPrefabs.Length);

            // By providing this object's transform as the last parameter,
            // we store all spawned objects under this spawner in the hierarchy.
            // This prevents clutter.
            Instantiate(sceneryPrefabs[typeOfScenery], spawnLocation, rotation, this.transform);


            // We will reduce the remaining distance by the size of this gap between this and the next building.
            float gapSize = Random.Range(minimumGap, maximumGap);
            remainingDifference -= gapSize;
        }
        
    }

    /*
     * THIS IS OLD UNUSED CODE AND IS ONLY HERE FOR REFERENCE
     */
    IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Wait a random number of seconds in between each spawning.
            float waitTime = Random.Range(minTimeBetweenObjects, maxTimeBetweenObjects);
            yield return new WaitForSeconds(waitTime);

            // Get a random index corresponding to our array of sceneryPrefabs
            int typeOfScenery = Random.Range(0, sceneryPrefabs.Length);

            // By providing this object's transform as the last parameter,
            // we store all spawned objects under this spawner in the hierarchy.
            // This prevents clutter.

            // If the object needs to be flipped, we apply a rotation.
            if (isMirrored == false)
            {
                Instantiate(sceneryPrefabs[typeOfScenery], this.transform.position, Quaternion.identity, this.transform);
            }
            else
            {
                Instantiate(sceneryPrefabs[typeOfScenery], this.transform.position, Quaternion.Euler(0f, 180f, 0f), this.transform);
            }
        }
    }
}
