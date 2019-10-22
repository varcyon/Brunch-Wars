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
    [SerializeField] float maxSpeed = 600f;
    [SerializeField] float showSpeed;
    [SerializeField] public enum SteeringType { Controller, Keyboard };
    [SerializeField] public SteeringType steeringType;
    [SerializeField] float rotateSpeed;
    [SerializeField] float rotateSpeedK;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] private GameObject phaserShot;
    [SerializeField] private Transform leftShootPoint;
    [SerializeField] private Transform rightShootPoint;
    [SerializeField] private Transform hotSaucePoint;
    [SerializeField] float attackTimer = 1f;
    float currentAttackTimer;
    bool canShoot;
    public GameObject canvasK;
    public GameObject canvasC;
    public Dropdown controller;
    public static ShipController Instance { get; set; }

    Vector2 mousePos;

    //////// Power UP
    [SerializeField] public bool hotSauce;
    [SerializeField] float HotSauseActive = 5f;
    [SerializeField] float HotSauseActiveCur = 0f;
    [SerializeField] GameObject hotSauceIcon;

    void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Awake()
    {
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
        controls.KMGamePlay.Point.performed += ctx => mousePos= ctx.ReadValue<Vector2>();
       // controls.KMGamePlay.Point.canceled += ctx => mousePos= ctx.ReadValue<Vector2>();
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
        ShipMove();
        CanShoot();
        showSpeed = rigidbody.velocity.magnitude;
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
                Instantiate(phaserShot, leftShootPoint.position, transform.rotation);
                Instantiate(phaserShot, rightShootPoint.position, transform.rotation);
                if (hotSauce)
                {
                    Instantiate(phaserShot, hotSaucePoint.position, transform.rotation);
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
                rigidbody.AddForce(acceleration * speed * Time.deltaTime);
                if (rigidbody.velocity.magnitude > maxSpeed)
                {
                    rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
                }
            }
            if (EngineReverse > 0f)
            {
                Vector3 acceleration = -transform.up;
                rigidbody.AddForce(acceleration * speed * Time.deltaTime);
                if (rigidbody.velocity.magnitude > maxSpeed)
                {
                    rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
                }
            }

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
                rigidbody.AddForce(acceleration * speed * Time.deltaTime);
                if (rigidbody.velocity.magnitude > maxSpeed)
                {
                    rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
                }
            }

            if (EngineReverse > 0f)
            {
                Vector3 acceleration = -transform.up;
                rigidbody.AddForce(acceleration * speed * Time.deltaTime);
                if (rigidbody.velocity.magnitude > maxSpeed)
                {
                    rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
                }
            }
        }
    }

    void PowerUps()
    {
        HotSauce();
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
            hotSauceIcon.SetActive(true);
        }
        else
        {
            hotSauceIcon.SetActive(false);
        }
    }

    /////////////////////////////////////////////
    public void ChangeController()
    {
        if (controller.value == 1)
        {
            steeringType = SteeringType.Keyboard;
            canvasK.gameObject.SetActive(true);
            canvasC.gameObject.SetActive(false);

        }

        if (controller.value == 0)
        {
            steeringType = SteeringType.Controller;
            canvasK.gameObject.SetActive(false);
            canvasC.gameObject.SetActive(true);
        }

    }

}

