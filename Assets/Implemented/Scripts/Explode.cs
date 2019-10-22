using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] int damage;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Damageable controller = other.gameObject.GetComponent<Damageable>();
        if (controller != null)
        {
            controller.TakeDamage(damage,other.gameObject);
        }

        Debug.Log("Boom!");
        
       LevelManger.Instance.enemies.Remove(gameObject);           
        Destroy(gameObject);
    }

}
