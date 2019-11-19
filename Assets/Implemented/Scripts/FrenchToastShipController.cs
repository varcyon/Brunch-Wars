using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrenchToastShipController : MonoBehaviour
{
   [HideInInspector]  [SerializeField] float playerDifferenceX;
  [HideInInspector]   [SerializeField] float playerDifferenceY;
  [HideInInspector]   [SerializeField] bool wasChasing;
    Vector3 targetPoint;
    [SerializeField] float turnSpeed = 2f;
    [SerializeField] float Speed = 3000f;
    Rigidbody2D rigidbody2D;

    [SerializeField] float chaseZone;
    public bool chasePlayer;
    [SerializeField] float attackRange;
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        ChangeDirection();
        Vector3 acceleration = transform.right;
        rigidbody2D.AddForce(acceleration * Speed * Time.deltaTime);

    }

    void Update()
    {
        playerDifferenceX = Mathf.Abs(ShipController.Instance.gameObject.transform.position.x - transform.position.x);
        playerDifferenceY = Mathf.Abs(ShipController.Instance.gameObject.transform.position.y - transform.position.y);

        if (playerDifferenceX < chaseZone && playerDifferenceY < chaseZone)
        {
            chasePlayer = true;
            wasChasing = true;
        }
        else if (wasChasing)
        {
            chasePlayer = false;
            wasChasing = false;
        }
        Move();
    }
 

    void ChangeDirection()
    {
        Vector2 direction = targetPoint - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }





    void Move()
    {
        if (chasePlayer)
        {
            targetPoint = ShipController.Instance.gameObject.transform.position;
            
        } else if(!chasePlayer){
           rigidbody2D.velocity = rigidbody2D.velocity * 0;
        }
      

    }
}


