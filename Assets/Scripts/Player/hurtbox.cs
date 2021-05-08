using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtbox : MonoBehaviour
{
    [SerializeField]
    float damage;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            Debug.Log("hit");
            collision.GetComponent<Enemy>().RecieveDamage(damage);
        }
        if (collision.gameObject.layer == 7)
        {
            //Destroy(collision.gameObject);
            //Destroy bullets here
        }
    }
}
