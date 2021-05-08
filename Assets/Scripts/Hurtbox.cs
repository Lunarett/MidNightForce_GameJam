using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtbox : MonoBehaviour
{
    [SerializeField]
    float damage;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            Debug.Log("dead");
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("bullet"))
        {

        }
    }
}
