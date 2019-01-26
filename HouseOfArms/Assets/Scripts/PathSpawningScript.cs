using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawningScript : MonoBehaviour
{
    //Group of the path object
    public GameObject[] PathObjects;
    //Default Path length
    public float PathLength = 15.0f;
    //When a path is _ distance behind it will teleport to the front
    public float DistanceBehindToTeleport = -15.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject path in PathObjects)
        {
            if(path.transform.position.z < DistanceBehindToTeleport)
            {
                path.transform.Translate(-path.transform.forward * PathLength * PathObjects.Length);
            }
        }
    }
}
