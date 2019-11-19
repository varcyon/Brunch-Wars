using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    ShipInput controls;
    Vector2 move = Vector2.zero;
    float engineForward;
    float EngineReverse;
    bool shoot;

    [HideInInspector] public bool miniMapShow = true;
     [SerializeField] float normalMaxSpeed = 13;
    [HideInInspector] [SerializeField] float currenMaxSpeed;
     [SerializeField] float boostedMaxSpeed;
    [HideInInspector] [SerializeField] float showSpeed;
    [HideInInspector] [SerializeField] float rotateSpeed;
    [HideInInspector] [SerializeField] float rotateSpeedK;
     [SerializeField] float normalSpeed = 700f;
    [HideInInspector] [SerializeField] float currentSpeed;
     [SerializeField] float boostedSpeed;
    [HideInInspector] [SerializeField] Rigidbody2D rigidbody;
    [HideInInspector] [SerializeField] ParticleSystem thurster1;
    [HideInInspector] [SerializeField] ParticleSystem thurster2;
    [HideInInspector] [SerializeField] private GameObject phaserShot;
    [HideInInspector] [SerializeField] private Transform leftShootPoint;
    [HideInInspector] [SerializeField] private Transform rightShootPoint;

    [HideInInspector] [SerializeField] private Transform hotSaucePoint;

    [HideInInspector] [SerializeField] private Transform jamPoint1;
    [HideInInspector] [SerializeField] private Transform jamPoint2;
    [HideInInspector] [SerializeField] private Transform jamPoint3;
    [HideInInspector] [SerializeField] private Transform jamPoint4;
    [HideInInspector] [SerializeField] private Transform jamPoint5;
    [HideInInspector] [SerializeField] private Transform jamPoint6;
    [HideInInspector] [SerializeField] private Transform jamPoint7;
    [HideInInspector] [SerializeField] private Transform jamPoint8;


    [SerializeField] float attackTimer = 0.3f;
    float currentAttackTimer;
    bool canShoot;
    [HideInInspector] public bool Pause = false;

    public static ShipController Instance { get; set; }

    Vector2 mousePos;

    //////// Power UP
    [HideInInspector] public bool hotSauce;
    [SerializeField] float HotSauseActive = 15f;
    [SerializeField] float HotSauseActiveCur = 0f;


    [HideInInspector] public bool jam;
    [SerializeField] float jamActive = 10f;
    float jamActiveCur = 0f;

    [HideInInspector] public bool blueBerry;
    [SerializeField] float blueBerryActive = 5f;
    float blueBerryActiveCur = 0f;

    [HideInInspector] public bool donut;
    [SerializeField] float donutActive = 30f;
    float donutActiveCur = 0f;

    [SerializeField] int rollPower = 200;
    void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Awake()
    {
        currentSpeed = normalSpeed;
        boostedSpeed = normalSpeed * 10;

        currenMaxSpeed = normalMaxSpeed;
        boostedMaxSpeed = normalMaxSpeed * 2;


        MakeSingleton();
        Controls();
    }

    void Controls()
    {
        controls = new ShipInput();

        GamePadControls();
        KMControls();
    }
    void GamePadControls()
    {
        controls.GamePadGamePlay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.GamePadGamePlay.Move.canceled += ctx => move = Vector2.zero;
        controls.GamePadGamePlay.Forward.performed += ctx => engineForward = ctx.ReadValue<float>();
        controls.GamePadGamePlay.Forward.canceled += ctx => engineForward = 0f;
        controls.GamePadGamePlay.Reverse.performed += ctx => EngineReverse = ctx.ReadValue<float>();
        controls.GamePadGamePlay.Reverse.canceled += ctx => EngineReverse = 0f;
        controls.GamePadGamePlay.Phaser.performed += ctx => shoot = true;
        controls.GamePadGamePlay.Phaser.canceled += ctx => shoot = false;
        controls.GamePadGamePlay.Select.performed += ctx => Pause = !Pause;

    }

    void KMControls()
    {
        controls.KMGamePlay.Forward.performed += ctx => engineForward = ctx.ReadValue<float>();
        controls.KMGamePlay.Forward.canceled += ctx => engineForward = 0f;
        controls.KMGamePlay.Reverse.performed += ctx => EngineReverse = ctx.ReadValue<float>();
        controls.KMGamePlay.Reverse.canceled += ctx => EngineReverse = 0f;
        controls.KMGamePlay.Phaser.performed += ctx => shoot = true;
        controls.KMGamePlay.Phaser.canceled += ctx => shoot = false;
        controls.KMGamePlay.Point.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
        controls.KMGamePlay.Tab.performed += ctx => miniMapShow = !miniMapShow;
        controls.KMGamePlay.Esc.performed += ctx => Pause = !Pause;

        controls.KMGamePlay.Roll_Port.performed += ctx => RollPort();
        controls.KMGamePlay.Roll_Starboard.performed += ctx => RollStarboard();
    }

    void Start()
    {
        currentAttackTimer = attackTimer;
    }

    void Update()
    {
        PowerUps();
    }
    void FixedUpdate()
    {
        StartEngines();
        ShipMove();
        CanShoot();


    }

    void StartEngines()
    {
        if (engineForward > 0.001f)
        {
            thurster1.gameObject.SetActive(true);
            thurster2.gameObject.SetActive(true);
        }
        else
        {
            thurster1.gameObject.SetActive(false);
            thurster2.gameObject.SetActive(false);

        }

    }


    void CanShoot()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > currentAttackTimer)
        {
            canShoot = true;
        }
        if (shoot)
        {
            if (canShoot)
            {
                canShoot = false;
                attackTimer = 0f;
                GameObject go = Instantiate(phaserShot, leftShootPoint.position, transform.rotation);
                GameObject go1 = Instantiate(phaserShot, rightShootPoint.position, transform.rotation);
                if (hotSauce)
                {
                    GameObject go3 = Instantiate(phaserShot, hotSaucePoint.position, transform.rotation);
                }
                if (jam)
                {
                    GameObject go4 = Instantiate(phaserShot, hotSaucePoint.position, transform.rotation);
                    GameObject go5 = Instantiate(phaserShot, jamPoint1.position, jamPoint1.rotation);
                    GameObject go6 = Instantiate(phaserShot, jamPoint2.position, jamPoint2.rotation);
                    GameObject go7 = Instantiate(phaserShot, jamPoint3.position, jamPoint3.rotation);
                    GameObject go8 = Instantiate(phaserShot, jamPoint4.position, jamPoint4.rotation);
                    GameObject go9 = Instantiate(phaserShot, jamPoint5.position, jamPoint5.rotation);
                    GameObject go10 = Instantiate(phaserShot, jamPoint6.position, jamPoint6.rotation);
                    GameObject go11 = Instantiate(phaserShot, jamPoint7.position, jamPoint7.rotation);
                    GameObject go12 = Instantiate(phaserShot, jamPoint8.position, jamPoint8.rotation);
                }
            }
        }
    }

    void ShipMove()
    {////////////////////////////////////////////////////
        if (PlayerPrefs.GetString("ControlDevice") == "Controller")

        {
            controls.GamePadGamePlay.Enable();
            controls.KMGamePlay.Disable();

            if (move.x == 0.0f && move.y == 0.0f)
            {
                transform.rotation = transform.rotation;
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(-move.x, move.y) * 180 / Mathf.PI)), rotateSpeed * Time.deltaTime);
            }

            if (engineForward > 0f)
            {
                Vector3 acceleration = transform.up;
                rigidbody.AddForce(acceleration * currentSpeed * Time.deltaTime);
                if (rigidbody.velocity.magnitude > currenMaxSpeed)
                {
                    rigidbody.velocity = rigidbody.velocity.normalized * currenMaxSpeed;
                }
            }

            if (EngineReverse > 0f)
            {
                Vector3 acceleration = -transform.up;
                rigidbody.AddForce(acceleration * currentSpeed * Time.deltaTime);
                if (rigidbody.velocity.magnitude > currenMaxSpeed)
                {
                    rigidbody.velocity = rigidbody.velocity.normalized * currenMaxSpeed;
                }
            }

        }
        /////////////////////////////////////////////


        if (PlayerPrefs.GetString("ControlDevice") == "Keyboard")
        {
            controls.GamePadGamePlay.Disable();
            controls.KMGamePlay.Enable();

            Vector2 mousePosConvert = new Vector2();
            mousePosConvert = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 direction = new Vector2(
                mousePosConvert.x - transform.position.x,
                mousePosConvert.y - transform.position.y);
            transform.up = direction;

            if (engineForward > 0f)
            {
                Vector3 acceleration = transform.up;
                rigidbody.AddForce(acceleration * currentSpeed * Time.deltaTime);
                if (rigidbody.velocity.magnitude > currenMaxSpeed)
                {
                    rigidbody.velocity = rigidbody.velocity.normalized * currenMaxSpeed;
                }
            }

            if (EngineReverse > 0f)
            {
                Vector3 acceleration = -transform.up;
                rigidbody.AddForce(acceleration * currentSpeed * Time.deltaTime);
                if (rigidbody.velocity.magnitude > currenMaxSpeed)
                {
                    rigidbody.velocity = rigidbody.velocity.normalized * currenMaxSpeed;
                }
            }
        }
    }
    void RollPort()
    {
        rigidbody.AddForce(-transform.right * rollPower);
    }
    void RollStarboard()
    {
        rigidbody.AddForce(transform.right * rollPower);
    }



    void PowerUps()
    {

        HotSauce();
        Jam();
        BlueBerry();
        Donut();
    }

    void HotSauce()
    {
        if (hotSauce)
        {
            HotSauseActiveCur += Time.deltaTime;
            if (HotSauseActiveCur >= HotSauseActive)
            {
                HotSauseActiveCur = 0;
                hotSauce = false;
            }
            PowerUpIcons.Instance.hotsauceIcon.SetActive(true);
        }
        else
        {
            PowerUpIcons.Instance.hotsauceIcon.SetActive(false);
        }
    }

    void Jam()
    {
        if (jam)
        {
            jamActiveCur += Time.deltaTime;
            if (jamActiveCur >= jamActive)
            {
                jamActiveCur = 0;
                jam = false;
            }
            PowerUpIcons.Instance.jamIcon.SetActive(true);
        }
        else
        {
            PowerUpIcons.Instance.jamIcon.SetActive(false);
        }
    }

    void BlueBerry()
    {
        if (blueBerry)
        {
            blueBerryActiveCur += Time.deltaTime;
            if (blueBerryActiveCur >= jamActive)
            {
                blueBerryActiveCur = 0;
                blueBerry = false;
            }

            currentSpeed = boostedSpeed;
            currenMaxSpeed = boostedMaxSpeed;
            PowerUpIcons.Instance.blueBerryIcon.SetActive(true);
        }
        else
        {
            currentSpeed = normalSpeed;
            currenMaxSpeed = normalMaxSpeed;
            PowerUpIcons.Instance.blueBerryIcon.SetActive(false);

        }
    }

    void Donut()
    {
        if (donut)
        {
            donutActiveCur += Time.deltaTime;
            if (donutActiveCur >= donutActive)
            {
                donutActiveCur = 0;
                donut = false;
            }
            PowerUpIcons.Instance.donutIcon.SetActive(true);
        }
        else
        {
            PowerUpIcons.Instance.donutIcon.SetActive(false);
        }
    }


}

