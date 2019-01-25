using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenerySpawning : MonoBehaviour
{
    // These are the prefabs we will instantiate during runtime
    public GameObject houseObject;
    public GameObject treeObject;

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

            // By providing this object's transform as the last parameter,
            // we store all spawned objects under this spawner in the hierarchy.
            // This prevents clutter.
            Instantiate(houseObject, this.transform.position, Quaternion.identity, this.transform);
        }
    }
}
