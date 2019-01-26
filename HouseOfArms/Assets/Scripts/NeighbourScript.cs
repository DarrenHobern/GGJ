using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourScript : MonoBehaviour
{
    [SerializeField] private Transform SpawnedStuff;
    [SerializeField] private Transform[] positionList;
    [SerializeField] private GameObject trashThing;
    [SerializeField] private Vector3 throwVelocity;
    [SerializeField] private float spawnDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSomething());
    }

    // Update is called once per frame
    void Update()
    {

    }

    Transform GetRandomChild()
    {
        int positionIndex = Random.Range(0, positionList.Length);
        int subPositionIndex = Random.Range(0, positionList[positionIndex].childCount);
        return positionList[positionIndex].GetChild(subPositionIndex);
    }

    IEnumerator SpawnSomething()
    {
        while (true)
        {
            Transform placeToSpawn = GetRandomChild();
            GameObject trashPiece = Instantiate(trashThing, placeToSpawn.position, placeToSpawn.rotation, SpawnedStuff);
            Rigidbody trashBody = trashPiece.GetComponent<Rigidbody>();
            // Only add the force if it's spawning from the sides! 
            trashBody.AddForce(throwVelocity);
            yield return new WaitForSeconds(spawnDelay);
        }

    }

}
