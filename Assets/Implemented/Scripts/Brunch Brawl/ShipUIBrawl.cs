using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShipUIBrawl : MonoBehaviourPun
{
    public float healthBarWidth;
    private float healthBarWidthSmooth;
    [SerializeField] float healthBarWidthEase;
    [SerializeField] GameObject healthBar;
    public GameObject miniMap;
        public PhotonView PV;

    public static ShipUIBrawl Instance { get; set; }

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        PV = ShipControllerBrawl.Instance.GetComponent<PhotonView>();
        healthBarWidth = 1;
        healthBarWidthSmooth = healthBarWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PV.IsMine){return;}

            healthBarWidth = (float)ShipControllerBrawl.Instance.GetComponent<DamageableBrawl>().health / (float)ShipControllerBrawl.Instance.GetComponent<DamageableBrawl>().maxHealth;
            healthBarWidthSmooth += (healthBarWidth - healthBarWidthSmooth) * Time.deltaTime * healthBarWidthEase;
            healthBar.transform.localScale = new Vector2(healthBarWidthSmooth, transform.localScale.y);

            if (ShipControllerBrawl.Instance.miniMapShow)
            {
                miniMap.SetActive(true);
            }
            else
            {
                miniMap.SetActive(false);
            }
        
    }
}
