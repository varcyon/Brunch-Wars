using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerealMinesShipController : MonoBehaviour
{
    [HideInInspector] [SerializeField] float playerDifferenceX;
    [HideInInspector] [SerializeField] float playerDifferenceY;
    [HideInInspector] [SerializeField] bool wasChasing;
    [SerializeField] float rotateSpeed = 2f;
    Rigidbody2D rigidbody2D;
    [HideInInspector] [SerializeField] Rotate rotate;
    [SerializeField] float attackRange;
    [HideInInspector] [SerializeField] GameObject sleeping;
    [HideInInspector] [SerializeField] GameObject awake;
    [SerializeField] int timeToExplode;
    [SerializeField] float boomZone;
    [SerializeField] int boomDamage;
    GameObject nullObject;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, boomZone);

    }
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
    }

    void Update()
    {
        playerDifferenceX = Mathf.Abs(ShipController.Instance.gameObject.transform.position.x - transform.position.x);
        playerDifferenceY = Mathf.Abs(ShipController.Instance.gameObject.transform.position.y - transform.position.y);

        if (playerDifferenceX < attackRange && playerDifferenceY < attackRange && LevelManger.Instance.canAttackPlayer)
        {
            sleeping.SetActive(false);
            awake.SetActive(true);
            rotate.enabled = true;
            rotate.rotateSpeed += rotateSpeed;
            StartCoroutine("Boom");
        }
        else
        {
            sleeping.SetActive(true);
            awake.SetActive(false);
            rotate.rotateSpeed = 10;
            rotate.enabled = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
            StopCoroutine("Boom");

        }
    }

    public IEnumerator Boom()
    {
        yield return new WaitForSeconds(timeToExplode);
        if (playerDifferenceX < boomZone && playerDifferenceY < boomZone)
        {
            ShipController.Instance.GetComponent<Damageable>().TakeDamage(boomDamage, nullObject);
            this.gameObject.GetComponent<Damageable>().TakeDamage(100000, nullObject);
        }


    }













}


