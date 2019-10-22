using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Damageable : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public int health { get { return currentHealth; } }

    public bool recovering;
    public float recoveryCounter;
    public float recoveryTime = 2;
    Animator animator;


    [SerializeField] GameObject deathParticles;




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
        Destroy(gameObject);
    }

    public void TakeDamage(int amount, GameObject other)
    {
        if (!recovering)
        {
          
            recoveryCounter = 0;
            recovering = true;
            currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        }
        if (health <= 0)
        {
            if (gameObject.layer == 8)
            {

            }
            else
            {
                if (other.gameObject.tag == "Enemy")
                {          
                    Die();
                    LevelManger.Instance.enemies.Remove(other.gameObject); 
                }
            }
        }
    }
    public void increaseHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
