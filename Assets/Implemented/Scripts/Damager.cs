using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 1;
    [SerializeField] bool isStaticArea;
    [SerializeField] GameObject shotCollision;


    void OnTriggerStay2D(Collider2D other)
    {

        if (isStaticArea)
        {
            Damageable controller = other.GetComponent<Damageable>();
            if (controller != null)
            {
                controller.TakeDamage(damage, other.gameObject);
            }
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "BeamCollider"){ return;}
        if(other.name == "DonutWall"){return;}
        if(other.name == "WaffleKingTrigger"){ return;}
        Damageable controller = other.GetComponent<Damageable>();
        if (controller != null)
        {
            controller.TakeDamage(damage, other.gameObject);
        }
        shotCollision.SetActive(true);
        shotCollision.transform.parent = transform.parent;
        Destroy(gameObject);
    }
}
