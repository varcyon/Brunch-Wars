using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Photon.Pun;
using System.IO;
using TMPro;

public class ShipControllerBrawl : MonoBehaviourPun
{
    public TextMeshProUGUI name;

    public PhotonView PV;
    ShipInput controls;
    Vector2 move = Vector2.zero;
    float engineForward;
    float EngineReverse;
    bool shoot;

    public bool miniMapShow = false;


    [SerializeField] float normalMaxSpeed = 10;
    [SerializeField] float currenMaxSpeed;
    [SerializeField] float boostedMaxSpeed;
    [SerializeField] float showSpeed;
    [SerializeField] public enum SteeringType { Controller, Keyboard };
    [SerializeField] public SteeringType steeringType;
    [SerializeField] float rotateSpeed;
    [SerializeField] float rotateSpeedK;
    [SerializeField] float normalSpeed = 200f;
    [SerializeField] float currentSpeed;
    [SerializeField] float boostedSpeed;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] ParticleSystem thurster1;
    [SerializeField] ParticleSystem thurster2;
    [SerializeField] private GameObject phaserShot;
    [SerializeField] private Transform leftShootPoint;
    [SerializeField] private Transform rightShootPoint;

    [SerializeField] private Transform hotSaucePoint;

    [SerializeField] private Transform jamPoint1;
    [SerializeField] private Transform jamPoint2;
    [SerializeField] private Transform jamPoint3;
    [SerializeField] private Transform jamPoint4;
    [SerializeField] private Transform jamPoint5;
    [SerializeField] private Transform jamPoint6;
    [SerializeField] private Transform jamPoint7;
    [SerializeField] private Transform jamPoint8;


    [SerializeField] float attackTimer = 1f;
    float currentAttackTimer;
    bool canShoot;

    public static ShipControllerBrawl Instance { get; set; }

    Vector2 mousePos;

    //////// Power UP
    [SerializeField] public bool hotSauce;
    [SerializeField] float HotSauseActive = 5f;
    [SerializeField] float HotSauseActiveCur = 0f;


    [SerializeField] public bool jam;
    [SerializeField] float jamActive = 5f;
    [SerializeField] float jamActiveCur = 0f;

    [SerializeField] public bool blueBerry;
    [SerializeField] float blueBerryActive = 5f;
    [SerializeField] float blueBerryActiveCur = 0f;

    [SerializeField] public bool donut;
    [SerializeField] float donutActive = 5f;
    [SerializeField] float donutActiveCur = 0f;


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
    }

    void Start()
    {
        currentAttackTimer = attackTimer;
        PV = GetComponent<PhotonView>();
        if(PV.IsMine){
            name.text = PhotonNetwork.NickName;
        } else{
            name.text = PV.Owner.NickName;
        }
    }

    void Update()
    {
        PowerUps();
    }
    void FixedUpdate()
    {
        StartEngines();
        if (PV.IsMine) {
        ShipMove();
        CanShoot();
        }

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
                GameObject go = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs",phaserShot.name), leftShootPoint.position, leftShootPoint.rotation);
                GameObject go1 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs",phaserShot.name), rightShootPoint.position, rightShootPoint.rotation);
                // CmdNetworkShoot(go);
                // CmdNetworkShoot(go1);
                if (hotSauce)
                {
                    GameObject go3 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs",phaserShot.name), hotSaucePoint.position, hotSaucePoint.rotation);
                }
                if (jam)
                {
                    GameObject go4 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs",phaserShot.name), hotSaucePoint.position, hotSaucePoint.rotation);
                    GameObject go5 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs",phaserShot.name), jamPoint1.position, jamPoint1.rotation);
                    GameObject go6 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs",phaserShot.name), jamPoint2.position, jamPoint2.rotation);
                    GameObject go7 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs",phaserShot.name), jamPoint3.position, jamPoint3.rotation);
                    GameObject go8 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs",phaserShot.name), jamPoint4.position, jamPoint4.rotation);
                    GameObject go9 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs",phaserShot.name), jamPoint5.position, jamPoint5.rotation);
                    GameObject go10 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs",phaserShot.name), jamPoint6.position, jamPoint6.rotation);
                    GameObject go11 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs",phaserShot.name), jamPoint7.position, jamPoint7.rotation);
                    GameObject go12 = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs",phaserShot.name), jamPoint8.position, jamPoint8.rotation);
                }
            }
        }
    }

    void ShipMove()
    {////////////////////////////////////////////////////
        if (steeringType == SteeringType.Controller)
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
            // if (EngineReverse > 0f)
            // {
            //     Vector3 acceleration = -transform.up;
            //     rigidbody.AddForce(acceleration * speed * Time.deltaTime);
            //     if (rigidbody.velocity.magnitude > maxSpeed)
            //     {
            //         rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
            //     }
            // }

        }
        /////////////////////////////////////////////


        if (steeringType == SteeringType.Keyboard)
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

            // if (EngineReverse > 0f)
            // {
            //     Vector3 acceleration = -transform.up;
            //     rigidbody.AddForce(acceleration * speed * Time.deltaTime);
            //     if (rigidbody.velocity.magnitude > maxSpeed)
            //     {
            //         rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
            //     }
            // }
        }
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



    /////////////////////////////////////////////
    // public void ChangeController()
    // {
    //     if (controller.value == 0)
    //     {
    //         steeringType = SteeringType.Keyboard;
    //         canvasK.gameObject.SetActive(true);
    //         canvasC.gameObject.SetActive(false);

    //     }

    //     if (controller.value == 1)
    //     {
    //         steeringType = SteeringType.Controller;
    //         canvasK.gameObject.SetActive(false);
    //         canvasC.gameObject.SetActive(true);
    //     }

    // }

}

