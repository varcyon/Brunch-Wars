using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour
{

    public List<GameObject> enemieBases = new List<GameObject>();
    public List<GameObject> livesIcon = new List<GameObject>();
    [SerializeField] GameObject playerStart;
    Scene activeScene;
    public string currentScene;
    [SerializeField] string level1;
    [SerializeField] string level2;
    [SerializeField] string level3;
    [SerializeField] string commanderWhipcream;
    [SerializeField] string waffleKing;
    [SerializeField] string victory;
    [SerializeField] string gameover;
    public bool gameSetup;

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

        playerStart = GameObject.FindGameObjectWithTag("PlayerStart");
        GameManager.Instance.playership.transform.position = playerStart.transform.position;

    }
    void Start()

    {
        gameSet();
    }

    private void gameSet()
    {
        activeScene = SceneManager.GetActiveScene();
        currentScene = activeScene.name;


        gameSetup = true;
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    IEnumerator switchScene(){
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
}


