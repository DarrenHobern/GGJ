using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    GameControlScript gm;
    public float leftBound = -5;
    public float rightBound = 5;
    public float speed = 1;
    public int lives = 3;
    public Text LivesTxt;

    void Start()
    {
        //LivesTxt.text = "Lives: " + lives;
        gm = GameControlScript.instance;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    /// <summary>
    /// Movement this instance.
    /// </summary>
    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(speed * horizontal, 0, 0));
        if (transform.position.x <= leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider thing)
    {
        if (thing.gameObject.CompareTag("GoodThing"))
        {
            Debug.Log(gm.score);
            gm.score += thing.gameObject.GetComponent<HitThing>().ScoreChange;
            Destroy(thing.gameObject);
            Debug.Log(gm.score);
        }
        else if (thing.gameObject.CompareTag("BadThing"))
        {
            Debug.Log(gm.score);
            gm.score += thing.gameObject.GetComponent<HitThing>().ScoreChange;
            Destroy(thing.gameObject);
            Debug.Log(gm.score);
            Destroy(thing.gameObject);
            lives--;
            if (lives <= 0)
            {
                gm.LoseGame();
            }
        }
    }
}
