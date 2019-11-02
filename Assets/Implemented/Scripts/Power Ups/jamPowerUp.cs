using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jamPowerUp : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            ShipController.Instance.jam = true;
            Destroy(gameObject);
        }
    }
}
