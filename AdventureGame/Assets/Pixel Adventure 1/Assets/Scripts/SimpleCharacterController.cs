using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class SimpleCharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravityScale = 1f;

    private Rigidbody2D rigidbody;
    private Vector2 velocity;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = gravityScale;
    }

    private void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        velocity.x = moveInput * moveSpeed;

        // Jumping
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            velocity.y = jumpForce;
        }

        rigidbody.velocity = velocity;
    }

    private bool IsGrounded()
    {
        // Implement a ground check using Raycasts or Physics2D.Raycast
        // Example using Physics2D.Raycast:
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
        return hit.collider != null;
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private Transform thisTransform;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        thisTransform = transform;
    }

    private void Update()
    {
        MoveCharacter();
        ApplyGravity();
        KeepCharacterOnXAxis();
    }
    private void MoveCharacter()
    {
        // Horizontal movement
        var moveInput = Input.GetAxis("Horizontal");
        var move = new Vector3(moveInput, 0f, 0f) * (moveSpeed * Time.deltaTime);
        controller.Move(move);
    
        // Jumping
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * 2f * gravity);
        }
    }
    
    private void ApplyGravity()
    {
        // Apply gravity when not grounded
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0f; // Reset velocity when grounded
        }
    
        // Apply the velocity to the controller
        controller.Move(velocity * Time.deltaTime);
    }
    
    private void KeepCharacterOnXAxis()
    {
        // Maintain character on the same z-axis position
        var currentPosition = thisTransform.position;
        currentPosition.z = 0f;
        thisTransform.position = currentPosition;
    }
}
*/