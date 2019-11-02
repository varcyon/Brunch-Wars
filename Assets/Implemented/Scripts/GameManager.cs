using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Lives = 3;
    public GameObject[] livesIcon = new GameObject[6];
    public static GameManager Instance { get; set; }
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
    private void Awake()
    {
        MakeSingleton();
    }


    private void Update()
    {
       // LivesUpdate();
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
