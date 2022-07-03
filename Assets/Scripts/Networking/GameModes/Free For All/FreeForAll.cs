using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using UnityEngine.UI;
public class FreeForAll : MonoBehaviour, IPunObservable
{
    public GameObject LobbyCamera;
    public Text SpawnCountDown;
    public float SpawnTime;
    float timer;
    bool HasPlayerSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        LobbyCamera.SetActive(true);
    }

   
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        SpawnCountDown.text = "Spawining In: " + Mathf.Round(timer);
        if(timer >= SpawnTime)
        {
            if(!HasPlayerSpawned)
            {
                LobbyCamera.SetActive(false);
                SpawnCountDown.gameObject.SetActive(false);
                PhotonNetwork.Instantiate("soldier", Vector3.zero, Quaternion.identity, 0);
                HasPlayerSpawned = true;
            }
            timer = 0;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
       if(stream.IsWriting)
        {

        }
       else if(stream.IsReading)
        {

        }
    }
}
