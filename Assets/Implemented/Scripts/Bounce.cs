using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
   
     void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Waffle King"){
            Debug.Log("hit bounce");
            if(this.name == "BouncerTop"){
            WaffleKingController.dir = -transform.up;
            }
            if(this.name == "BouncerBtn"){
            WaffleKingController.dir = transform.up;
            }
        }
    }
}
