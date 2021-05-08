using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D myRB;

    [SerializeField]
    float acceleration,maxSpeedSqr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        myRB.AddForce(new Vector2(Input.GetAxis("Horizontal") * acceleration, Input.GetAxis("Vertical") * acceleration));
        if (Input.GetAxis("Horizontal") <= 0.2 && Input.GetAxis("Horizontal") >= -0.2)
        {
            myRB.velocity = new Vector2(0, myRB.velocity.y);
        }
        if (Input.GetAxis("Vertical") <= 0.2 && Input.GetAxis("Vertical") >= -0.2)
        {
            myRB.velocity = new Vector2(myRB.velocity.x, 0);
        }

        if (myRB.velocity.sqrMagnitude <= maxSpeedSqr)
        {
            myRB.velocity = myRB.velocity.normalized * maxSpeedSqr;
        }

        //myRB.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized*movementSpeed;
    }
}
