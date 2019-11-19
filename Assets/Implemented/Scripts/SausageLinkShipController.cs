using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SausageLinkShipController : MonoBehaviour
{
    public bool attackPlayer;
    [SerializeField] Transform[] destinations;
  [HideInInspector]   [SerializeField] float playerDifferenceX;
   [HideInInspector]  [SerializeField] float playerDifferenceY;
  [HideInInspector]   [SerializeField] GameObject leftShootPoint;
   [HideInInspector]  [SerializeField] GameObject rightShootPoint;
   [HideInInspector]  [SerializeField] GameObject MiddleShootPoint;
    [HideInInspector] [SerializeField] GameObject phaserShot;
    Vector3[] worldDestinations;
    Vector3 targetPoint;
    [SerializeField] float distThreshold = .02f;
    [SerializeField] float turnSpeed = 2f;
    [SerializeField] float Speed = 2f;
    int numOfWaypoints;
    int currentWaypoint = 0;
    Rigidbody2D rigidbody2D;
    float attackTimer = 0.5f;
    float currentAttackTimer;
    bool patrol = true;
   [HideInInspector]  [SerializeField] bool wasAttacking;

    [SerializeField] float chaseZone;
    [SerializeField] float attackRange;
  [HideInInspector]   [SerializeField] bool shootMiddle;
    public static SausageLinkShipController Instance;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        for (int i = 0; i < destinations.Length; i++)
        {
            if (i == destinations.Length - 1)
            {
                Gizmos.DrawLine(destinations[destinations.Length - 1].position, destinations[0].position);
            }
            else
            {
                Gizmos.DrawLine(destinations[i].position, destinations[i + 1].position);
            }
        }

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseZone);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Instance = this;
    }
    void Start()
    {
        currentAttackTimer = attackTimer;
        numOfWaypoints = destinations.Length - 1;
        worldDestinations = new Vector3[destinations.Length];
        for (int i = 0; i < destinations.Length; i++)
        {
            worldDestinations[i] = destinations[i].position;
        }
        targetPoint = worldDestinations[currentWaypoint];

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        ChangeDirection();
        //  
        if (attackPlayer) { return; }
        Vector3 acceleration = transform.right;
        rigidbody2D.AddForce(acceleration * Speed * Time.deltaTime);
    }

    void Update()
    {
        playerDifferenceX = Mathf.Abs(ShipController.Instance.gameObject.transform.position.x - transform.position.x);
        playerDifferenceY = Mathf.Abs(ShipController.Instance.gameObject.transform.position.y - transform.position.y);
        if (playerDifferenceX < attackRange && playerDifferenceY < attackRange)
        {
            attackPlayer = true;
            patrol = false;
            wasAttacking = true;
        }
        else if (wasAttacking)
        {
            wasAttacking = false;
            attackPlayer = false;
            patrol = true;
            NextPoint();
        }
        Move();
    }
    void Patrolling()
    {
        if (Vector3.Distance(transform.position, targetPoint) < distThreshold)
        {
            NextPoint();
        }


    }

    void NextPoint()
    {
        if (currentWaypoint > numOfWaypoints)
        {
            currentWaypoint = 0;
        }
        targetPoint = worldDestinations[currentWaypoint];

        currentWaypoint++;
    }

    void ChangeDirection()
    {
        Vector2 direction = targetPoint - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }



    void Shooting()
    {
        attackTimer += Time.deltaTime;
        if (playerDifferenceX <= attackRange && playerDifferenceY <= attackRange && LevelManger.Instance.canAttackPlayer)
        {

            if (attackTimer > currentAttackTimer)
            {
                transform.position = transform.position;
                attackTimer = 0f;
                GameObject es1 = Instantiate(phaserShot, leftShootPoint.transform.position, transform.rotation);
                es1.transform.Rotate(0f, 0f, -90f);
                GameObject es2 = Instantiate(phaserShot, rightShootPoint.transform.position, transform.rotation);
                es2.transform.Rotate(0f, 0f, -90f);
                if(shootMiddle){
                    GameObject es3 = Instantiate(phaserShot, MiddleShootPoint.transform.position, transform.rotation);
                es3.transform.Rotate(0f, 0f, -90f);
                }
            }
        }
    }

    void Move()
    {
        if (attackPlayer)
        {
            targetPoint = ShipController.Instance.gameObject.transform.position;
            Shooting();
        }
        if (patrol)
        {
            Patrolling();
        }

    }
}


