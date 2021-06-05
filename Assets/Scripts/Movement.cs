using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float moveMagnitude;
    [SerializeField] private float rotationMagnitude;
    
    [Header("Drag")]
    [SerializeField] private float dragFactor;
    [SerializeField] private float minimumDrag;
    [SerializeField] private DragEquation dragEquation;

    private new Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        AdjustDrag();
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

        rigidbody2D.AddForce(transform.right * newMagnitude);
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

        rigidbody2D.AddTorque(newMagnitude, ForceMode2D.Impulse);
    }

    /**
     * Drag
     *   What should it be on edges to stop moving
     *     What happens on bottom edge (water? land?)
     *   What should it be in the middle
     *   Equations, exponential is possible too
     * Mass
     * Add an impulse force on top
     * Gravity making it harder to go up?
     * Limit move magnitude by a y-position factor
     */
    private void AdjustDrag()
    {
        float drag = rigidbody2D.drag;

        switch (dragEquation)
        {
            case DragEquation.None:
                drag = rigidbody2D.drag;
                break;
            case DragEquation.Linear:
                drag = transform.position.y * dragFactor + minimumDrag;
                break;
            case DragEquation.Square:
                drag = Mathf.Pow(transform.position.y * dragFactor, 2) + minimumDrag;
                break;
            case DragEquation.Exponential:
                drag = dragFactor * Mathf.Exp(transform.position.y) + minimumDrag;
                break;
            default:
                break;
        }

        rigidbody2D.drag = drag;
    }
}

public enum DragEquation
{
    None,
    Linear,
    Square,
    Exponential,
}
