using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryMovement : MonoBehaviour
{
    // Speed which the object moves towards the player
    public float MovingSpeed = 5f;

    // The distance behind the camera at which point the object loops back to the start
    public float ResetDistanceFromCamera = 2.0f;

    // When the object resets, it goes here. It is the Transform of the parent spawner.
    public Vector3 PositionToResetTo;

    // When the object gets here, it will reset.
    Vector3 PositionToResetFrom;

    // Start is called before the first frame update
    void Start()
    {
        PositionToResetFrom = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        PositionToResetTo   = transform.parent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.forward * MovingSpeed * Time.deltaTime);

        if (PositionToResetFrom.z > ResetDistanceFromCamera + transform.position.z)
        {
            transform.position = PositionToResetTo;
        }
    }
}