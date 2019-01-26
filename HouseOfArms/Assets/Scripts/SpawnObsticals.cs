using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObsticals : MonoBehaviour
{
    public GameObject[] Obsticles;
    public Vector2 MinMaxSideSpawn = new Vector2(-3.0f, 3.0f);
    public float DistanceInfrontOfCamera = 45.0f;
    public float TimeBetweenSpawns = 1.0f;
    public float TimeBetweenSpawnsDecreaseAmount = 0.1f;

    private float TimeTillNextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        TimeTillNextSpawn = Time.time + 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeTillNextSpawn < Time.time)
        {
            int RandomObjectToSpawn = Random.Range(0, Obsticles.Length);
            Instantiate(Obsticles[RandomObjectToSpawn], this.transform.position 
            + new Vector3(Random.Range(MinMaxSideSpawn.x, MinMaxSideSpawn.y), 0.0f, 
                DistanceInfrontOfCamera), Obsticles[RandomObjectToSpawn].transform.rotation);

            TimeBetweenSpawns -= TimeBetweenSpawnsDecreaseAmount * Time.deltaTime;
            TimeTillNextSpawn = Time.time + TimeBetweenSpawns;
        }
    }
}
