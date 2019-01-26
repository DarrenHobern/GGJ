using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour
{
    public static GameControlScript instance = null;


    public float score = 0;
    public GameObject PauseScreen;
    public GameObject GameOverScreen;
    private int peopleCollected = 0;
    [SerializeField] private int bossThresholdOne = 10;
    [SerializeField] private int bossThresholdTwo = 20;
    [SerializeField] private int bossThresholdThree = 30;

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
        //TogglePauseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause") || Input.GetKeyDown("joystick button 7")) //getaxis
        {
            TogglePauseMenu();
        }



    }

    public void AddPerson()
    {
        peopleCollected++;
        if (peopleCollected >= bossThresholdThree)
        {
            // Trigger third boss fight
        }
        else if (peopleCollected >= bossThresholdTwo)
        {
            // Trigger second boss fight
        }
        else if (peopleCollected >= bossThresholdOne)
        {
            // Trigger first boss fight
        }

    }

    private void TurnOffRegularMode()
    {

    }

    public void LoseGame()
    {
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);

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

    public bool GetPaused()
    {
        return Pause;
    }
}
