using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    //Group of the path object
    public GameObject[] PathObjects;
    //Default Path length
    public float PathLength = 100.0f;
    //When a path is _ distance behind it will teleport to the front
    public float DistanceBehindToTeleport = -100.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject path in PathObjects)
        {
            if (path.transform.position.z < DistanceBehindToTeleport)
            {
                path.transform.Translate(path.transform.forward * 100.0f * PathObjects.Length);
            }
        }
    }
}
