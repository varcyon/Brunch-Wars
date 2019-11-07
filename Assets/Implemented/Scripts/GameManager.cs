using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int Lives = 3;
        [SerializeField] CinemachineVirtualCamera virtualCam;
           public GameObject playership;


    public static GameManager Instance { get; set; }
    void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        } else if(Instance !=this){
            Destroy(gameObject);
        }
    }
     void Awake()
    {
        MakeSingleton();
        DontDestroyOnLoad(gameObject);
        

    }


     void Update()
    {
  
        virtualCam =  GameObject.FindGameObjectWithTag("VC").GetComponent<CinemachineVirtualCamera>();
                virtualCam.Follow = playership.transform;
    }
}
