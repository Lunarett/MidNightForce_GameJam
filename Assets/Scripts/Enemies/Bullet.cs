using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float damage;
    PlayerHealth playerHealth;

    [FMODUnity.EventRef]
    [SerializeField]
    string bulletSpawn;

    [FMODUnity.EventRef]
    [SerializeField]
    string bulletHit;

    public void Init(PlayerHealth playerHealth, float damage)
    {
        this.playerHealth = playerHealth;
        this.damage = damage;

        FMODUnity.RuntimeManager.PlayOneShot(bulletSpawn, transform.position);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int layer = collision.gameObject.layer;
        if (layer == LayerMask.NameToLayer("Enemy")) return;

        if (collision.transform.TryGetComponent(out PlayerController pc))
        {
            //Hardcoded to 1
            pc.GetComponent<PlayerHealth>().takeDamage(1);
        }

        Destroy(gameObject);
        FMODUnity.RuntimeManager.PlayOneShot(bulletHit, transform.position);
    }

}
