using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEveryBeat : OnBeatBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float bulletSpeed;


    public override void OnBeat()
    {
        Debug.Log("Shoot");
        Shoot();
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position + transform.up * bullet.transform.localScale.x / 2, transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity += new Vector2(bullet.transform.up.x, bullet.transform.up.y).normalized*bulletSpeed;
        
    }
}
