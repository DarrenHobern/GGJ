using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenerySpawning : MonoBehaviour
{
    public GameObject houseObject;

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
            float waitTime = Random.Range(minTimeBetweenObjects, maxTimeBetweenObjects);
            yield return new WaitForSeconds(waitTime);

            Instantiate(houseObject, this.transform.position, Quaternion.identity);
        }
    }
}
