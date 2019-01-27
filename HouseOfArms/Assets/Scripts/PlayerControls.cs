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
    [SerializeField] private const int maxLives = 20;
    private int lives;
    public Text LivesTxt;
    public Text ScoreTxt;

    public GameObject CollectedBad;
    public GameObject CollectedGood;

    [Header("Ammo and Bullets")]
    [SerializeField] private int bulletPoolSize = 30;
    [SerializeField] private Transform gunTransform;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Vector3 gunForce;
    [SerializeField] private float attackDelay = 0.1f;
    [SerializeField] private float reloadTime = 2f;
    [SerializeField] private float bulletLife = 5f;
    private float nextAttackTime = 0;
    private int personCount = 0; // also the magazine size
    private int ammoCount = 0;
    private bool reloading = false;

    void Start()
    {
        gm = GameControlScript.instance;
        SimplePool.Preload(bulletPrefab, bulletPoolSize);
        Reset();
        if (LivesTxt)
        {
            LivesTxt.text = "Property value points: " + lives;
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
        Attack();
    }

    private void Reset() {
        lives = maxLives;
        personCount = 1;
        ammoCount = 1;
        reloading = false;
        nextAttackTime = 0;
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

    private void Attack() {
        if (gm.GetPaused()) return;

        bool attackInput = Input.GetAxisRaw("Fire") > Mathf.Epsilon;
        if (attackInput) {
            if (ammoCount > 0) {
                if (Time.time >= nextAttackTime) {
                    nextAttackTime = Time.time + attackDelay;
                    ammoCount--;
                    // Fire a person here
                    // GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation); // TODO object pooling
                    GameObject bullet = SimplePool.Spawn(bulletPrefab, gunTransform.position, gunTransform.rotation);
                    bullet.GetComponent<Rigidbody>().AddForce(gunForce);
                    StartCoroutine(DespawnBullet(bullet, bulletLife));
                }
            }
            else if (!reloading) {
                // start reloading
                reloading = true;
                StartCoroutine(Reload());
            }
            
        }
    }

    IEnumerator DespawnBullet(GameObject bullet, float delay) {
        yield return new WaitForSeconds(delay);
        SimplePool.Despawn(bullet);
    }     

    IEnumerator Reload() {
        yield return new WaitForSeconds(reloadTime);
        ammoCount = personCount;
        reloading = false;
        print("done");
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
            personCount++;
            if(0 == Input.GetAxisRaw("Fire"))
            {
                ammoCount += 1;
            }
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
                LivesTxt.text = "Property value points: " + lives;
            }
            if (lives <= 0)
            {
                gm.EndGame(false);
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
