using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class MPManager : MonoBehaviourPunCallbacks
{
    public GameObject[] EnableObjectsOnConnect;
    public GameObject[]DisableObjectsOnConnect;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        //PhotonNetwork.ConnectToRegion("au");
    }

    public override void OnConnectedToMaster()
    {
        foreach(GameObject obj in EnableObjectsOnConnect)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in DisableObjectsOnConnect)
        {
            obj.SetActive(false);
        }
        Debug.Log("We are now Connected to Photon!");

    }

    public void JoinF4A()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateF4A();
    }

    public void CreateF4A()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        RoomOptions ro = new RoomOptions { MaxPlayers = 10, IsOpen = true, IsVisible = true };
        PhotonNetwork.CreateRoom("defaultF4A",ro, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("FreeForAll");

    }
}
