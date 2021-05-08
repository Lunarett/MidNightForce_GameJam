using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int layer = collision.gameObject.layer;
        if (layer == LayerMask.NameToLayer("Enemy")) return;

        if (layer == LayerMask.NameToLayer("Player")) 
        Debug.Log(collision);
        Destroy(gameObject);
    }

}
