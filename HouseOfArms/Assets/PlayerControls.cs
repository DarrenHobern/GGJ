using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float leftBound = -5;
    public float rightBound = 5;
    public float speed = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Debug.Log(horizontal);
        transform.Translate(new Vector3(speed*horizontal, 0, 0));
        if (transform.position.x <= leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }
    }
}
