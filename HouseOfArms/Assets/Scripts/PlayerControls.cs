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
    public Text ScoreTxt;

    public GameObject CollectedBad;
    public GameObject CollectedGood;

    void Start()
    {
        gm = GameControlScript.instance;
        if (LivesTxt)
        {
            LivesTxt.text = "Resale value points: " + lives;
        }
        if(ScoreTxt)
        {
            ScoreTxt.text = "Rent: $" + gm.score;
        }

        if (CollectedBad && CollectedGood)
        {
            CollectedBad.SetActive(false);
            CollectedGood.SetActive(false);
        }
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
        if (!gm.GetPaused())
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
    }

    private void OnTriggerEnter(Collider thing)
    {
        if (thing.gameObject.CompareTag("GoodThing"))
        {
            if (thing.GetComponent<ObjectMovement>())
            {
                thing.GetComponent<ObjectMovement>().SeperateChildAudio();
            }
            
            gm.score += thing.gameObject.GetComponent<HitThing>().ScoreChange;
            Destroy(thing.gameObject);
            gm.AddPerson();

            if (CollectedGood)
            {
                CollectedGood.transform.position = this.transform.position + new Vector3(0.0f, 0.0f, -0.5f);
                CollectedGood.SetActive(true);
            }
        }
        else if (thing.gameObject.CompareTag("BadThing"))
        {
            if (thing.GetComponent<ObjectMovement>())
            {
                thing.GetComponent<ObjectMovement>().SeperateChildAudio();
            }
            gm.score += thing.gameObject.GetComponent<HitThing>().ScoreChange;
            Destroy(thing.gameObject);
            lives--;
            if (LivesTxt)
            {
                LivesTxt.text = "Resale value points: " + lives;
            }
            if (lives <= 0)
            {
                gm.LoseGame();
            }

            if (CollectedBad)
            {
                CollectedBad.transform.position = this.transform.position + new Vector3(0.0f, 0.0f, -0.5f);
                CollectedBad.SetActive(true);
            }
        }
        if (ScoreTxt)
        {
            ScoreTxt.text = "Rent: $" + gm.score;
        }
    }
}
