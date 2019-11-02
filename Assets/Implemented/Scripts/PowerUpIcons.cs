using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpIcons : MonoBehaviour
{
        public static PowerUpIcons Instance { get; set; }

        public GameObject hotsauceIcon;
        public GameObject jamIcon;
        public GameObject blueBerryIcon;
        public GameObject donutIcon;

private void Awake() {
    
        if (Instance == null)
        {
            Instance = this;
        }
       
    
}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
