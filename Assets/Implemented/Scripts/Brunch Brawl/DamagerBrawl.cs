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
        photonView.RPC("RPC_damage", RpcTarget.All, other);

    }

    [PunRPC]
    void RPC_damage(Collider2D other)
    {
        Damageable controller = other.GetComponent<Damageable>();
        if (controller != null)
        {
            if (other.gameObject.tag == "Player")
            {
                controller.TakeDamage(damage, other.gameObject);
            }
        }
    }
}
