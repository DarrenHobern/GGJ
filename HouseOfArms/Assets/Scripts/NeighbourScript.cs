using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourScript : MonoBehaviour
{
    [SerializeField] private Transform SpawnedStuff;
    [Tooltip("Right, Back, Left")]
    [SerializeField] private Transform[] positionList;
    [SerializeField] private GameObject trashThing;
    [SerializeField] private Vector3 throwVelocity;
    [SerializeField] private float spawnDelay = 5.0f;

    private WaitForSeconds wait;

    // Start is called before the first frame update
    void Start()
    {
        wait = new WaitForSeconds(spawnDelay);
        StartCoroutine(SpawnSomething());
    }

    Transform GetRandomChild(out int direction)
    {
        int positionIndex = Random.Range(0, positionList.Length);
        direction = positionIndex -1; // convert 0,1,2 --> -1, 0 , 1 for right, back, left
        int subPositionIndex = Random.Range(0, positionList[positionIndex].childCount);
        return positionList[positionIndex].GetChild(subPositionIndex);
    }

    IEnumerator SpawnSomething()
    {
        while (true)
        {
            Transform placeToSpawn = GetRandomChild(out int direction);
            GameObject trashPiece = Instantiate(trashThing, placeToSpawn.position, placeToSpawn.rotation, SpawnedStuff);
            Rigidbody trashBody = trashPiece.GetComponent<Rigidbody>();

            trashBody.AddForce(new Vector3(throwVelocity.x * direction, throwVelocity.y, throwVelocity.z));
            yield return wait;
        }

    }

}
