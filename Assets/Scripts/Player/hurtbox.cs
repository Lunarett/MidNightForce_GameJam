using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtbox : MonoBehaviour
{
    [SerializeField]
    float damage;

    [FMODUnity.EventRef]
    [SerializeField]
    string hitSound;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Enemy enemy))
        {
            enemy.RecieveDamage(damage);
            FMODUnity.RuntimeManager.PlayOneShot(hitSound, transform.position);
        }

        if (collider.TryGetComponent(out Bullet bullet))
        {
            Destroy(collider.gameObject);
        }
    }
}
