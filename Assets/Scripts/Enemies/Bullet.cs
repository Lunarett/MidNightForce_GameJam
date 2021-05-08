using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float damage;
    PlayerHealth playerHealth;
    public void Init(PlayerHealth playerHealth, float damage)
    {
        this.playerHealth = playerHealth;
        this.damage = damage;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int layer = collision.gameObject.layer;
        if (layer == LayerMask.NameToLayer("Enemy")) return;

        Debug.Log(damage);
        if (layer == LayerMask.NameToLayer("Player")) playerHealth.takeDamage(damage);
        Destroy(gameObject);
    }

}
