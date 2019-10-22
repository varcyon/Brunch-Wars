using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipUI : MonoBehaviour
{
    [SerializeField] private float healthBarWidth;
	private float healthBarWidthSmooth;
	[SerializeField] private float healthBarWidthEase;
    [SerializeField] GameObject healthBar;

    void Start()
    {
        healthBarWidth = 1;
		healthBarWidthSmooth = healthBarWidth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBarWidth = (float)ShipController.Instance.GetComponent<Damageable>().health / (float)ShipController.Instance.GetComponent<Damageable>().maxHealth;
		healthBarWidthSmooth += (healthBarWidth - healthBarWidthSmooth) * Time.deltaTime * healthBarWidthEase;
		healthBar.transform.localScale = new Vector2 (healthBarWidthSmooth, transform.localScale.y);
        
    }
}
