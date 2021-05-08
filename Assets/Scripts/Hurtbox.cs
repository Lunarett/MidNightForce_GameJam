using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtbox : MonoBehaviour
{
    [SerializeField]
    float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("bullet"))
        {

        }
    }
}
