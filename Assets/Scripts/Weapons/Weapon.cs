using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;

public abstract class Weapon : MonoBehaviourPun
{
    public GameObject Bullet;
    public GameObject ShootPoint;
    private string WeaponName;
    private int WeaponDamage;

    public Weapon(string WeaponName, int WeaponDamage)
    {
        this.WeaponName = WeaponName;
        this.WeaponDamage = WeaponDamage;
    }

    void Start()
    {
        foreach (Transform t in gameObject.transform)
        {
            if (t.tag == "Bullet")
            {
                //ShootPoint = t.gameObject;
            }
        }
        WeaponStart();
    }

    public void Shoot(Vector3 point)
    {
        photonView.RPC("RpcShoot", RpcTarget.All,point);
    }
    
    [PunRPC]
   public void RpcShoot(Vector3 point)
    {
        GameObject bullet = Instantiate(Bullet, ShootPoint.transform.position, ShootPoint.transform.rotation);
        //Rigidbody br = bullet.GetComponent<Rigidbody>();
        //br.velocity = vel;
        bullet.transform.LookAt(point);
        Destroy(bullet, 4);
    }

  

  
    void Update()
    {
        WeaponUpdate();
    }

    public abstract void WeaponStart();
    public abstract void WeaponUpdate();
}
