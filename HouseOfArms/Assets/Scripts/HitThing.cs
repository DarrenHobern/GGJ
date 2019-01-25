using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitThing : MonoBehaviour
{
    [SerializeField] private int scoreChange = 1;
    public int ScoreChange
    {
        get { return this.scoreChange; }
        private set { this.scoreChange = value; }
    } 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
