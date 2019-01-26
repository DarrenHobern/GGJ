using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    //Spped which the object moves towards the player
    public float MovingSpeed = 5.0f;
    //Can this be deleted
    public bool CanBeDeleted = true;
    //The distance behind the camera where it gets deleted
    public float DeletionDistance = 2.0f;
    //Can the object move sideways
    public bool CanMoveSideways = false;
    //Sideways movement Speed
    public float SidewaysMovementSpeed = 2.0f;
    //If the object can move sideways, give the min and max position it can move
    public Vector2 MinMaxSidewaysMovement = new Vector2(-3.0f, 3.0f);

    //CurrentSidewaysDirection
    private bool MovingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        int iTemp = Random.Range(0, 2);
        if (0 == iTemp)
        {
            MovingRight = true;
        }
        else
        {
            MovingRight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.forward * MovingSpeed * Time.deltaTime);

        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        if (camera)
        {
            if(camera.transform.position.z > DeletionDistance + transform.position.z)
            {
                if (CanBeDeleted)
                {
                    Destroy(this.gameObject);
                }
            }
        }

        if (CanMoveSideways)
        {
            if (MovingRight)
            {
                transform.Translate(transform.right * SidewaysMovementSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-transform.right * SidewaysMovementSpeed * Time.deltaTime);
            }
            if(transform.position.x < MinMaxSidewaysMovement.x || transform.position.x > MinMaxSidewaysMovement.y)
            {
                MovingRight = !MovingRight;
            }
        }
    }
}
