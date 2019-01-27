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

        if (CanMoveSideways)
        {
            if (MovingRight)
            {
                transform.Rotate(transform.rotation.x, 45.0f, transform.rotation.z);
            }
            else
            {
                transform.Rotate(transform.rotation.x, -45.0f, transform.rotation.z);
            }
        }
        else
        {
            MovingSpeed /= 2.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody>())
        {
            Debug.Log("Applying Force");
            GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, -1.0f) * MovingSpeed * 50.0f * Time.deltaTime);
        }
        else
        {
            transform.Translate(-transform.forward * MovingSpeed * Time.deltaTime); //TODO make object face the way it's moving
        }

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
                transform.Translate(transform.right * MovingSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-transform.right * MovingSpeed * Time.deltaTime);
            }
            if (transform.position.x < MinMaxSidewaysMovement.x && MovingRight)
            {
                MovingRight = false;
                transform.Rotate(transform.rotation.x, -90.0f, transform.rotation.z);
            }
            else if (transform.position.x > MinMaxSidewaysMovement.y && !MovingRight)
            {
                MovingRight = true;
                transform.Rotate(transform.rotation.x, 90.0f, transform.rotation.z);
            }
        }
    }

    public void SeperateChildAudio()
    {
        if (GetComponentInChildren<AudioSource>())
        {
            GetComponentInChildren<AudioSource>().pitch = Random.Range(0.75f, 1.25f);
            GetComponentInChildren<AudioSource>().Play();
            Destroy(GetComponentInChildren<AudioSource>().gameObject, 2.0f);
            GetComponentInChildren<AudioSource>().transform.parent = null;
        }
    }
}
