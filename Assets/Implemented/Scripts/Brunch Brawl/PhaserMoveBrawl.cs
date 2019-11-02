using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhaserMoveBrawl : MonoBehaviourPun
{
    [SerializeField] float speed = 50f;
    float destroy = 1f;

    //  void OnTriggerEnter2D(Collider2D other) {
    //     Debug.Log("hit");
    //     if(other.gameObject.tag == "Enemy"){
    //         LevelManger.Instance.enemies.Remove(other.gameObject);            
    //     }
    //     Destroy(other.gameObject);
    //     Destroy(gameObject);
    // }

    IEnumerator destroyPhaser()
    {
        yield return new WaitForSeconds(destroy);
        this.GetComponent<PhotonView>().RPC("DestroyGameObject",RpcTarget.AllBuffered);
    }
    void Update()
    {
        move();
    }

    void move()
    {
        Vector3 acceleration = transform.up;
        transform.position += acceleration * speed * Time.deltaTime;
    }
    [PunRPC]
    void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }
}
