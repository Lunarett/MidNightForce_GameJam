using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidbody;

    [SerializeField]
    float acceleration, maxSpeed, idleDrag;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(horizontal, vertical, 0);
        if (input.sqrMagnitude > 1) input.Normalize();

        if (input.sqrMagnitude > 0.1f)
        {
            rigidbody.AddForce(input * Time.fixedDeltaTime * acceleration, ForceMode2D.Impulse);

            if (rigidbody.velocity.magnitude > maxSpeed)
                rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;

            transform.right = rigidbody.velocity;
        }
        else
        {
            rigidbody.velocity *= 1 - Time.fixedDeltaTime * idleDrag;
        }
    }
}
