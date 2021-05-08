using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtbox : MonoBehaviour
{
    [SerializeField]
    float damage;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Enemy enemy))
        {
            Debug.Log("hit");
            enemy.RecieveDamage(damage);
        }
    }
}
