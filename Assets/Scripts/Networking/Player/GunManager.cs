using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;

public class GunManager : MonoBehaviourPun
{

    public GameObject HoldPosition;
    public GameObject LeftHand;
    public GameObject CurrentOwnedWeapon;
    GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Movement>().cam;
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (Physics.Raycast(ray, out hit, 3f))
                {
                    if (hit.collider.tag == "Weapon")
                    {
                        //PhotonNetwork.Destroy(hit.collider.GetComponent<PhotonView>());
                        photonView.RPC("ClaimWeapon", RpcTarget.AllBuffered, hit.collider.GetComponent<PhotonView>().ViewID);
                    }
                }
            }
            
            if(CurrentOwnedWeapon != null)
            {
                
                RaycastHit hitBullet;
                if(Input.GetMouseButtonDown(0))
                {
                    if (Physics.Raycast(ray, out hitBullet))
                    {
                        //Vector3 dir = hitBullet.point - gameObject.transform.position;
                        CurrentOwnedWeapon.GetComponent<Weapon>().Shoot(hitBullet.point);
                    }
                }

                
            }
        }
        LeftHand.transform.position = HoldPosition.transform.position;
    }
    [PunRPC]
    void ClaimWeapon(int id)
    {
        GameObject gun = PhotonView.Find(id).gameObject;
        gun.transform.SetParent(HoldPosition.transform);
        gun.transform.position = HoldPosition.transform.position;
        gun.transform.rotation = HoldPosition.transform.rotation;
        CurrentOwnedWeapon = gun;

    }
}
