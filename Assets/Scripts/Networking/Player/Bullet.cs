using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int DamageAmount = 15;
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            PlayerData pd = collision.gameObject.GetComponent<PlayerData>();
            pd.TakeDamage(DamageAmount);
        }
        DestroyBullet();
    }
    void DestroyBullet()
    {
        Destroy(gameObject);

    }
}
