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
               ShipController.Instance.GetComponent<Damageable>().deathParticles.Add(Instantiate(GameManager.Instance.deathParticlesOBJ));
               // instantiate
               ShipController.Instance.GetComponent<Damageable>().deathParticles[GameManager.Instance.Lives-1].SetActive(false);
               ShipController.Instance.GetComponent<Damageable>().deathParticles[GameManager.Instance.Lives-1].transform.position = ShipController.Instance.gameObject.transform.position;
               ShipController.Instance.GetComponent<Damageable>().deathParticles[GameManager.Instance.Lives-1].transform.SetParent(ShipController.Instance.transform) ;
               
            } else {
                other.gameObject.GetComponent<Damageable>().increaseHealth(healAmount);
            }
            Destroy(gameObject);
        }
    }
}
