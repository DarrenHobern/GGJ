using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position.x);
        float sample = Mathf.PerlinNoise(transform.position.x, transform.position.y)-0.5f;
        transform.Translate(new Vector3(sample, sample/2, 0));

    }
}
