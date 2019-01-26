using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenerySpawning : MonoBehaviour
{
    // This will hold the prefabs we will instantiate during runtime
    public GameObject[] sceneryPrefabs = new GameObject[3];

    // If we want to mirror objects on one side of the road, we set this to true
    public bool isMirrored;

    public float minimumGap;
    public float maximumGap;

    void Start()
    {
        // Find the distance between the camera and the end of the spawn zone,
        // and fill that distance with scenery objects.
        
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
            GameObject obj = Instantiate(sceneryPrefabs[typeOfScenery], spawnLocation, rotation, this.transform);

            if (obj.tag == "Tree")
            {
                obj.transform.localScale = GetRandomTreeScaling();
            }

            // We will reduce the remaining distance by the size of this gap between this and the next building.
            float gapSize = Random.Range(minimumGap, maximumGap);
            remainingDifference -= gapSize;
        }
        
    }

    Vector3 GetRandomTreeScaling ()
    {
        float scale_x = Random.Range(0.2f, 0.6f);
        float scale_y = Random.Range(0.3f, 0.7f);
        float scale_z = Random.Range(0.2f, 0.6f);

        return new Vector3(scale_x, scale_y, scale_z);
    }

    /*
     * THIS IS OLD UNUSED CODE AND IS ONLY HERE FOR REFERENCE
     */
    /*
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
    */
}