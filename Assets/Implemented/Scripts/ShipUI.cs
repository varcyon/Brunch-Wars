using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipUI : MonoBehaviour
{
    [SerializeField] private float healthBarWidth;
    private float healthBarWidthSmooth;
    [SerializeField] private float healthBarWidthEase;
    [SerializeField] GameObject healthBar;
    public GameObject miniMap;
    public static ShipUI Instance { get; set; }
    [SerializeField] TextMeshProUGUI level;

private void Awake() {
    
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
        level.text = LevelManger.Instance.currentScene;
    }

    // Update is called once per frame
    void Update()
    {


        if (ShipController.Instance == null)
        { return; }

        healthBarWidth = (float)ShipController.Instance.GetComponent<Damageable>().health / (float)ShipController.Instance.GetComponent<Damageable>().maxHealth;
        healthBarWidthSmooth += (healthBarWidth - healthBarWidthSmooth) * Time.deltaTime * healthBarWidthEase;
        healthBar.transform.localScale = new Vector2(healthBarWidthSmooth, transform.localScale.y);

        if(ShipController.Instance.miniMapShow){
            miniMap.SetActive(true);
        } else {
            miniMap.SetActive(false);
        }


    }
}
