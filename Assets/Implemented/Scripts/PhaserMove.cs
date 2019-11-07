using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PhaserMove : MonoBehaviour
{
    [SerializeField] float speed = 500f;
    float destroy = 1f;

    //  void OnTriggerEnter2D(Collider2D other) {
    //     Debug.Log("hit");
    //     if(other.gameObject.tag == "Enemy"){
    //         LevelManger.Instance.enemies.Remove(other.gameObject);            
    //     }
    //     Destroy(other.gameObject);
    //     Destroy(gameObject);
    // }

    void Start()
    {
        Invoke("DestroyGameObject", destroy);
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

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
