using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    public Camera cam;
    public Rigidbody rb;
    public float forceMagnitude;
    public float maxVelocity;
    public float rotationSpeed;
    Vector3 movementDirection;

    void Update()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchposition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = cam.ScreenToWorldPoint(touchposition);
            movementDirection = transform.position - worldPosition;
            movementDirection.z = 0;
            movementDirection.Normalize();
        }
        else
        {
            movementDirection = Vector3.zero;
        }
        keepPlayerOnScreen();
        rotatetoFaceVelocity();
        
    }

    private void FixedUpdate()
    {
        if (movementDirection == Vector3.zero)
        {
            return;
        }
        rb.AddForce(movementDirection*forceMagnitude*Time.deltaTime , ForceMode.Force );
        rb.velocity = Vector3.ClampMagnitude(rb.velocity , maxVelocity);
    }

    void keepPlayerOnScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewportPosition = cam.WorldToViewportPoint(transform.position);
        if (viewportPosition.x > 1)
        {
            newPosition.x = -(newPosition.x) + 0.1f;
        }

        else if (viewportPosition.x < 0)
        {
            newPosition.x = -(newPosition.x) - 0.1f;
        }
        
        else  if (viewportPosition.y > 1)
        {
            newPosition.y = -(newPosition.y) + 0.1f;
        }

        else if (viewportPosition.y < 0)
        {
            newPosition.y = -(newPosition.y) - 0.1f;
        }

        transform.position = newPosition;
    }

    void rotatetoFaceVelocity()
    {
        if (rb.velocity == Vector3.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(rb.velocity, Vector3.back);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }
}
