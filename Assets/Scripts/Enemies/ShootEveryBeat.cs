using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEveryBeat : OnBeatBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private Transform parent;


    private PlayerHealth playerHealth;

    [SerializeField]
    float damage;


    public override void OnBeat()
    {
        Shoot();
    }

    private void Shoot()
    {
        //Debug.Log("Shoot");
        GameObject newBullet = Instantiate(bullet, transform.position + transform.up, transform.rotation, parent);
        newBullet.GetComponent<Bullet>().Init(playerHealth, damage);
        newBullet.GetComponent<Rigidbody2D>().velocity+=new Vector2(transform.up.x, transform.up.y).normalized*bulletSpeed;
        
    }
}
