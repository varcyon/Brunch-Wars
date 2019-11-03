using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DamagerBrawl : MonoBehaviourPun
{
    // Start is called before the first frame update
    public int damage = 1;
    [SerializeField] bool isStaticArea;


    void OnTriggerStay2D(Collider2D other)
    {

        if (isStaticArea)
        {
        photonView.RPC("RPC_damage", RpcTarget.All, other);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
          DamageableBrawl controller = other.GetComponent<DamageableBrawl>();
        if (controller != null)
        {
            if (other.gameObject.tag == "Player"){
            string hitName = other.gameObject.name;
            photonView.RPC("RPC_damage", RpcTarget.All, hitName);
            }
        }
        
    }

    [PunRPC]
    void RPC_damage(string hitName)
    {
        GameObject hitPlayer = GameObject.Find(hitName);
        hitPlayer.GetComponent<DamageableBrawl>().TakeDamage(damage);
    }
}
