using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShipUIBrawl : MonoBehaviourPun
{
    [SerializeField] private float healthBarWidth;
    private float healthBarWidthSmooth;
    [SerializeField] private float healthBarWidthEase;
    [SerializeField] GameObject healthBar;
    public GameObject miniMap;
    public static ShipUIBrawl Instance { get; set; }

    private void Awake()
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

    void Start()
    {

        healthBarWidth = 1;
        healthBarWidthSmooth = healthBarWidth;
    }

    // Update is called once per frame
    void Update()
    {
        
            if (ShipControllerBrawl.Instance == null)
            { return; }

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
