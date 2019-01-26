using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour
{
    public static GameControlScript instance = null;


    public float score = 0;
    public GameObject PauseScreen;
    private int peopleCollected = 0;
    [SerializeField] private GameObject[] bosses;
    [SerializeField] private int bossThreshold = 10;

    [SerializeField] private GameObject ObstacleSpawner;

    private int nextBoss = 0; // the index of the nextBoss
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
        StartGame(); 
    }

    void StartGame() {
        foreach (GameObject boss in bosses) {
            boss.SetActive(false);
        }
        ObstacleSpawner.SetActive(true);
        // Disable the pause screen.
        Pause = true;
        TogglePauseMenu();
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

        if (peopleCollected % bossThreshold == 0 && peopleCollected > 0) {
            EnterBossMode();
        }

    }


    private void EnterBossMode()
    {
        print("Enterring boss mode");
        ObstacleSpawner.SetActive(false);
        bosses[nextBoss].SetActive(true);
        // TODO check if the bossindex == bosses.length: win game.
        nextBoss++;

    }

    public void ExitBossMode() {
        ObstacleSpawner.SetActive(true);
        if (nextBoss >= bosses.Length) {
            EndGame(true);
        }
    }

    public void EndGame(bool win)
    {
        Debug.Log("Ending the game");
        if (win) {
            print("Winner winner chicken dinner");
        }
        else {
            print("Git gud");
        }

        // End the game, show the score screen.
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
