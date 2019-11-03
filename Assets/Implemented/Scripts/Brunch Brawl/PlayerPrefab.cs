using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class PlayerPrefab : MonoBehaviour
{
    public GameObject ShipPrefab;
    void Start()
    {
    // SpawnShip(); 
    }

    void Update()
    {

    }

    public void SpawnShip()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "ShipMP"), Vector3.zero, Quaternion.identity);
    }
}
