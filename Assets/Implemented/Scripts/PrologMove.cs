using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologMove : MonoBehaviour
{  [SerializeField] int speed = 2;
    void Update()
    {
       gameObject. transform.Translate(0,Time.deltaTime * speed, 0, Space.World);

       if(gameObject.transform.position.y > 50f){
           SceneManager.LoadScene("Level 1");
       }
    }

   
}
