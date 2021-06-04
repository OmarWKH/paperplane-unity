using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveMagnitude;
    [SerializeField] private float rotationMagnitude;

    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float newMagnitude = moveMagnitude;

        if (Input.GetKey("space"))
        {
            newMagnitude *= 0;
        }
        else
        {
            newMagnitude *= 1;
        }

        newMagnitude *= Time.fixedDeltaTime;

        GetComponent<Rigidbody2D>().AddForce(transform.right * newMagnitude);
    }

    private void Rotate()
    {
        float newMagnitude = rotationMagnitude;

        if (Input.GetKey("w"))
        {
            newMagnitude *= 1;
        }
        else if (Input.GetKey("s"))
        {
            newMagnitude *= -1;
        }
        else
        {
            newMagnitude *= 0;
        }
        
        newMagnitude *= Time.fixedDeltaTime;

        GetComponent<Rigidbody2D>().AddTorque(newMagnitude, ForceMode2D.Impulse);
    }
}
