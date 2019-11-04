using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Cinemachine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSetupController : MonoBehaviour
{
    GameObject playership;
    [SerializeField] CinemachineVirtualCamera virtualCam;
    public static List<GameObject> playerList = new List<GameObject>();
    [SerializeField] List<GameObject> playerListDisplay = new List<GameObject>();

    [SerializeField] GameObject winningPanel;
    [SerializeField] TextMeshProUGUI winningName;
    bool gameActive;
    void Start()
    {
        CreatePlayer(); //Create a networked player object for each player that loads into the multiplayer scenes.

        virtualCam.Follow = playership.transform;

        Invoke("SetupPlayerList", 5f);
        gameActive = true;

    }

    private void SetupPlayerList()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            playerList.Add(player);
        }
    }

    private void Update()
    {
        while(!gameActive){ return;}
         playerListDisplay = playerList;
        if (playerList.Count == 1)
        {
            winningPanel.SetActive(true);
            winningName.text = playerList[0].name;
            Time.timeScale = 0;
            gameActive = false;
        }
    }
    private void CreatePlayer()
    {
        Debug.Log("Creating Player");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), Vector3.zero, Quaternion.identity);
        playership = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "ShipMP"), Vector3.zero, Quaternion.identity);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GoToMainMenu(){
        PhotonNetwork.Disconnect();
        // while(PhotonNetwork.IsConnected){
        //     return;
        // }
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToLobby(){
        PhotonNetwork.Disconnect();
        // while(PhotonNetwork.IsConnected){
        //     return;
        // }
        SceneManager.LoadScene("Lobby");
    }
}
