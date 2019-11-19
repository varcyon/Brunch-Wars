using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int Lives = 3;
    // [SerializeField] CinemachineVirtualCamera virtualCam;
    // [SerializeField] CinemachineConfiner VCconfiner;
    public GameObject playership;
    public GameObject deathParticlesOBJ;

    PolygonCollider2D VCconfiningObj;


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
    void Awake()
    {
        MakeSingleton();
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        PlayerPrefs.SetString("ControlDevice", "Keyboard");
    }

    void Update()
    {
        

        if (LevelManger.Instance.playerIsDead)
        {
            StartCoroutine("playerDeath");
        }
    }
    ///////////////////////////////////////////

    public IEnumerator playerDeath()
    {
        LevelManger.Instance.playerIsDead = false;
        ShipController.Instance.GetComponent<Damageable>().deathParticles[0].SetActive(true);
        ShipController.Instance.GetComponent<Damageable>().deathParticles[0].transform.parent = transform.parent;
        ShipController.Instance.GetComponent<Damageable>().deathParticles.RemoveAt(0);
        GameManager.Instance.Lives--;
        ShipController.Instance.gameObject.SetActive(false);
        LevelManger.Instance.canAttackPlayer = false;
        yield return new WaitForSeconds(3f);
        if (GameManager.Instance.Lives == 0)
        {
            LevelManger.Instance.GameOver = true;
        }
        yield return new WaitForSeconds(0.5f);
        ShipController.Instance.gameObject.transform.position = LevelManger.Instance.playerStart.transform.position;

        ShipController.Instance.GetComponent<Damageable>().currentHealth = ShipController.Instance.GetComponent<Damageable>().maxHealth;
        ShipController.Instance.gameObject.SetActive(true);
        LevelManger.Instance.canAttackPlayer = true;
    }


}
