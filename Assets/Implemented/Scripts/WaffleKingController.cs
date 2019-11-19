using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaffleKingController : MonoBehaviour
{
    [SerializeField] List<GameObject> shootPoints = new List<GameObject>();
    [SerializeField] GameObject shot;
    [SerializeField] float attackRate;
    float timer;
    float currentAttackTimer;
    [SerializeField] float moveSpeed = 0.1f;
    public static Vector3 dir;
    Damageable damageable;
    bool moveMe = true;
    public static bool shooting = false;
    [SerializeField] GameObject beamWaypoint;
    [SerializeField] GameObject startPoint;
    [SerializeField] GameObject waffleBeam;
    [SerializeField] float rotateSpeed = 50f;

    [SerializeField] float beamAttackDuration;
    [SerializeField] bool isBeaming = false;
    bool preformedBeam;
    float beamTimer;
    void Start()
    {
        dir = transform.up;
        damageable = GetComponent<Damageable>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (damageable.currentHealth <= damageable.maxHealth / 2 && preformedBeam == false)
        {
            isBeaming = true;
        }
        shoot();
        move();
        Beam();
    }

    void shoot()
    {
        if (shooting)
        {
            timer += Time.deltaTime;
            if (timer >= attackRate)
            {
                timer = 0;
                foreach (GameObject shotPoint in shootPoints)
                {
                    Instantiate(shot, shotPoint.transform.position, Quaternion.Euler(0, 0, 90));
                }
            }
        }
    }

    void move()
    {
        if (moveMe)
        {
            transform.Translate(dir * moveSpeed);
        }
    }

    void Beam()
    {

        if (isBeaming)
        {
            beamTimer += Time.deltaTime;
            if (beamTimer < beamAttackDuration)
            {
                moveMe = false;
                shooting = false;
                transform.position = beamWaypoint.transform.position;
                // start beam
                waffleBeam.SetActive(true);
                transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
                preformedBeam = true;

            }
            else
            {
                waffleBeam.SetActive(false);
                isBeaming = false;
                transform.eulerAngles = new Vector3(0, 0, 0);
                transform.position = startPoint.transform.position;
                isBeaming = false;
                moveMe = true;
                shooting = true;
            }
        }
    }
}
