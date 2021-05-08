using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Attack : MonoBehaviour
{
    [SerializeField]
    GameObject hurtbox;

    [SerializeField]
    Rigidbody2D myRB;

    [SerializeField]
    float attackLength;

    float attackMoment;

    bool attackRunning = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attackRunning)
        {
            if (attackMoment <= Time.time)
            {
                attackRunning = false;
                hurtbox.SetActive(false);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                attackRunning = true;
                hurtbox.SetActive(true);
                attackMoment = Time.time + attackLength;
            }
        }

    }
}
