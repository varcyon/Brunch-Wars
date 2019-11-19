using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoAni : MonoBehaviour
{
   float timer;
   float currentTimer;
   float aniTime =3.5f;
    void Start()
    {
        currentTimer = aniTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if( timer >= aniTime){
            SceneManager.LoadScene("Main Menu");
        }
    }
}
