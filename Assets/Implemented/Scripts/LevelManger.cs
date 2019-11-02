using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour
{

    public List<GameObject> enemies = new List<GameObject>();

    public static LevelManger Instance { get; set; }
    void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Awake(){
        MakeSingleton();
    }
    void Start()
    {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("EnemyBase"))
        {
            enemies.Add(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.Count == 0){
             SceneManager.LoadScene("Level 2");
        }
    }
}
