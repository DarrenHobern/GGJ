using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenerySpawning : MonoBehaviour
{
    // This will hold the prefabs we will instantiate during runtime
    public GameObject[] sceneryPrefabs = new GameObject[2];

    public float minTimeBetweenObjects;
    public float maxTimeBetweenObjects;

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
            Instantiate(sceneryPrefabs[typeOfScenery], this.transform.position, Quaternion.identity, this.transform);
        }
    }
}
