using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBerry : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            ShipController.Instance.blueBerry = true;
            Destroy(gameObject);
        }
    }
}
