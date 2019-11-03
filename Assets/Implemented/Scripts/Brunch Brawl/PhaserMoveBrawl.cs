using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhaserMoveBrawl : MonoBehaviourPun,IPunObservable
{
    [SerializeField] float speed = 50f;
    float destroy = 1f;
    public bool destrythis;

     void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("hit" + other.gameObject.name);
        // if(other.gameObject.tag == "Enemy"){
        //     LevelManger.Instance.enemies.Remove(other.gameObject);            
        // }
        // Destroy(other.gameObject);
        photonView.RPC("DestroyGameObject",RpcTarget.AllBuffered);

    }

    IEnumerator destroyPhaser()
    {
        yield return new WaitForSeconds(destroy);
        photonView.RPC("DestroyGameObject",RpcTarget.AllBuffered);
    }
     void Start() {
        StartCoroutine("destroyPhaser");
    }
    void Update()
    {
        move();
        if(destrythis){
            Destroy(this.gameObject);
        }
    }

    void move()
    {
        Vector3 acceleration = transform.up;
        transform.position += acceleration * speed * Time.deltaTime;
    }
    [PunRPC]
    void DestroyGameObject()
    {
        destrythis = true;
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting){
            stream.SendNext(destrythis);
        } else if(stream.IsReading){
            destrythis = (bool)stream.ReceiveNext();
        }
    }
}
