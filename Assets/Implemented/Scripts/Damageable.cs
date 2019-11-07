using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Damageable : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public int health { get { return currentHealth; } }
    [SerializeField]GameObject parent;

    public bool recovering;
    public float recoveryCounter;
    public float recoveryTime = 2;
    Animator animator;


    [SerializeField] List<GameObject> deathParticles = new List<GameObject>();




    void Start()
    {
        //animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {

        if (recovering)
        {
            recoveryCounter += Time.deltaTime;
            if (recoveryCounter >= recoveryTime)
            {
                recoveryCounter = 0;
                recovering = false;
            }
        }
    }

    private void Die()
    {
        foreach (GameObject item in deathParticles)
        {
            item.SetActive(true);
        }
        foreach (GameObject item in deathParticles)
        {
            item.transform.parent = transform.parent;
        }
        Destroy(gameObject);
    }

    public void TakeDamage(int amount, GameObject other)
    {
        // not the player
        if (gameObject.tag != "Player")
        {
            currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
            if (health <= 0)
            {
                if (other.gameObject.tag == "EnemyBase")
                {
                    Die();
                    LevelManger.Instance.enemieBases.Remove(other.gameObject);
                }
                Die();
            }
        }

        // the player
        if (gameObject.tag == "Player")
        {
            if (!ShipController.Instance.donut)
            {
                if (!recovering)
                {
                    recoveryCounter = 0;
                    recovering = true;
                    currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
                }
            }
            if (health <= 0)
            {
            }

        }
    }
    public void increaseHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
