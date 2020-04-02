using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float gravity = 10.0f; //Let's create gravity manually so it's easier to tinker with
    [SerializeField] private float maxVelocityChange = 10.0f;

    private Rigidbody rb;
    private InputController playerInput;

    private bool canMove = true;

    void Awake()
    {
        playerInput = GetComponent<InputController>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    Vector3 targetVelocity;

    void FixedUpdate()
    {
        if (canMove)
        {
            
            //Calculate how out target velocity based on current input
            targetVelocity = new Vector3(playerInput.Horizontal, 0, playerInput.Vertical);


            // diagnal movement clamping to a magnitude of 1
            if (targetVelocity.magnitude > 1)
                targetVelocity = Vector3.Normalize(targetVelocity) * speed;
            else
                targetVelocity *= speed;


            //Apply a force that tries to reach the target velocity, but does not exceed maxVelocityChange
            Vector3 velocityChange = targetVelocity - rb.velocity;


            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);

            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
        //Apply gravity
        rb.AddForce(Vector3.down * gravity);
    }
}
