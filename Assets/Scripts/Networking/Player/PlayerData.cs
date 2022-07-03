using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;
using Photon.Pun;

public class PlayerData : MonoBehaviourPun, IPunObservable
{
    public GameObject[] MyObjects;
    public Text HealtText;
    public int Health;
    public int MaxHealth;
    public int MinHealt;
    GameObject LobbyCam;

    void Start()
    {
        if(photonView.IsMine)
        {
            foreach(GameObject o in MyObjects)
            {
                o.SetActive(true);
            }
            foreach(GameObject o in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (o.tag == "LobbyCam")
                {
                    LobbyCam = o;
                }
            }
        }
    }
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            if (Health < MinHealt)
            {
                Health = MinHealt;
                LobbyCam.SetActive(true);
                photonView.RPC("DoDeath", RpcTarget.All);
            }
            HealtText.text = Health + "/" + MaxHealth;
        }
    }

    [PunRPC]
    void DoDeath()
    {
        gameObject.SetActive(false);
    }

    public void TakeDamage(int amount)
    {
        if(photonView.IsMine)
        {
            photonView.RPC("Damage", RpcTarget.All, amount);
        }
    }

    [PunRPC]
    void Damage(int amount)
    {
        Health -= amount;
    }

   

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(Health);
            

        }
        else if(stream.IsReading)
        {
            Health = (int)stream.ReceiveNext();
            

        }
    }
}
