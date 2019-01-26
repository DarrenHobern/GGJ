using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour
{
    public static GameControlScript instance = null;
    public float score = 0;
    public GameObject PauseScreen;

    private bool Pause = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void LoseGame()
    {
        Debug.Log("End the Game in the game control script!");
        // call game control function here
    }

    public void TogglePauseMenu()
    {
        if (Pause)
        {
            Time.timeScale = 1;
            PauseScreen.SetActive(false);
            Pause = false;
        }
        else
        {
            Time.timeScale = 0;
            PauseScreen.SetActive(true);
            Pause = true;
        }
    }
}
