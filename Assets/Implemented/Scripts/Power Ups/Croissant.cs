using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Croissant : MonoBehaviour
{
    [SerializeField] int healAmount = 5;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            if(other.gameObject.GetComponent<Damageable>().currentHealth == other.gameObject.GetComponent<Damageable>().maxHealth){
               GameManager.Instance.Lives++;
            } else {
                other.gameObject.GetComponent<Damageable>().increaseHealth(healAmount);
            }
            Destroy(gameObject);
        }
    }
}
