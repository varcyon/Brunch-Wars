using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Cinemachine;
public class GameSetupController : MonoBehaviour
{
    GameObject playership;
    [SerializeField] CinemachineVirtualCamera virtualCam;
    void Start()
    {
        CreatePlayer(); //Create a networked player object for each player that loads into the multiplayer scenes.

       virtualCam.Follow = playership.transform;
    }
    private void CreatePlayer()
    {
        Debug.Log("Creating Player");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), Vector3.zero, Quaternion.identity);
       playership = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "ShipMP"), Vector3.zero, Quaternion.identity);
    }
}
