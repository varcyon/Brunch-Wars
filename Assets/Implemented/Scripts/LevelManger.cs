using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour
{

    public List<GameObject> enemieBases = new List<GameObject>();
    public List<GameObject> livesIcon = new List<GameObject>();
    public GameObject playerStart;
    Scene activeScene;
    public string currentScene;
    [SerializeField] string level1;
    [SerializeField] string level2;
    [SerializeField] string level3;
    [SerializeField] string commanderWhipcream;
    [SerializeField] string waffleKing;
    [SerializeField] string victory;
    [SerializeField] string gameover;
    [SerializeField] string MainMenu;
    public bool GameOver;
    public bool gameSetup;
    public bool playerIsDead;
    public bool canAttackPlayer = true;
    [SerializeField] GameObject pauseMenu;

    public static LevelManger Instance { get; set; }
    void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }
    void Awake()
    {
        gameSetup = false;
        MakeSingleton();


        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("EnemyBase"))
        {
            enemieBases.Add(enemy);
        }
        foreach (GameObject life in GameObject.FindGameObjectsWithTag("LivesIcon"))
        {
            livesIcon.Add(life);
        }


    }
    void Start()

    {
        gameSet();
    }

    private void gameSet()
    {
        activeScene = SceneManager.GetActiveScene();
        currentScene = activeScene.name;
        ShipController.Instance.gameObject.transform.position = LevelManger.Instance.playerStart.transform.position;

        gameSetup = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameOver)
        {
            SceneManager.LoadScene("Game Over");
        }
        if (LevelManger.Instance.currentScene != "Victory" || LevelManger.Instance.currentScene != "Game Over")
        {
            LivesUpdate();
        }

        if (gameSetup)
        {
            if (enemieBases.Count == 0)
            {
                StartCoroutine(switchScene());
            }
        }

         if (ShipController.Instance.Pause)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }


    
    IEnumerator switchScene()
    {
        yield return new WaitForSeconds(5f);
        switch (currentScene)
        {
            case "Level 1":
                SceneManager.LoadScene("Level 2");
                break;
            case "Level 2":
                SceneManager.LoadScene("Level 3");
                break;
            case "Level 3":
                SceneManager.LoadScene("Commander Whipcream");
                break;
            case "Commander Whipcream":
                SceneManager.LoadScene("Waffle King");
                break;
            case "Waffle King":
                SceneManager.LoadScene("Victory");
                break;

            default:
                break;
        }
    }
    public void LivesUpdate()
    {
        foreach (GameObject life in livesIcon)
        {
            life.SetActive(false);
        }
        for (int i = 0; i < GameManager.Instance.Lives; i++)
        {
            livesIcon[i].SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}


