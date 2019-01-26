using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenerySpawning : MonoBehaviour
{
    // This will hold the prefabs we will instantiate during runtime
    public GameObject[] sceneryPrefabs = new GameObject[2];

    public float minTimeBetweenObjects;
    public float maxTimeBetweenObjects;

    // If we want to mirror objects on one side of the road, we set this to true
    public bool isMirrored;

    void Start()
    {
        StartCoroutine (SpawnObjects());
    }

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
