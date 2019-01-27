using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControlScript : MonoBehaviour
{
    public static GameControlScript instance = null;

    [Tooltip("The number of bosses you must beat to win the game.")]
    [SerializeField] int bossesToBeat = 3;
    public float score = 0;
    [SerializeField] private GameObject PauseScreen;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private Text WinText;
    [SerializeField] private Text LoseText;
    private int peopleCollected = 0;
    [SerializeField] private BossScript[] bosses;
    [SerializeField] private int bossThreshold = 10;

    [SerializeField] private GameObject ObstacleSpawner;

    private int nextBoss = 0; // the index of the nextBoss
    private int defeatedBosses = 0;
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
        SimplePool.ClearPools();
        foreach (BossScript boss in bosses) {
            boss.Reset();
        }
        ObstacleSpawner.SetActive(true);

        // disable pause and gameover screens
        PauseScreen.SetActive(false);
        GameOverScreen.SetActive(false);
        Time.timeScale = 1;
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
        ObstacleSpawner.SetActive(false);
        bosses[nextBoss].Activate();
        nextBoss = (nextBoss+1) % (bosses.Length);

    }

    public void ExitBossMode() {
        ObstacleSpawner.SetActive(true);
        defeatedBosses++;
        if (defeatedBosses >= bossesToBeat) {
            EndGame(true);
        }
    }

    public void EndGame(bool win)
    {
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);
        Pause = true;
        
        WinText.gameObject.SetActive(win);
        LoseText.gameObject.SetActive(!win);
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
