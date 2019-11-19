using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWaffleKingBattle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject wall;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
        wall.SetActive(true);
        WaffleKingController.shooting = true;
        Destroy(this.gameObject);
        }
    }
}
