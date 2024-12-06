using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    protected float moveSpeed = 5f; // Assign a default speed

    private Vector2 movementInput; // Vector to store movement input

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found!");
        }
    }

    void Update()
    {
        // Handle input every frame
        movementInputHandler();
    }

    void FixedUpdate()
    {
        // Apply movement in FixedUpdate for smooth physics interactions
        MoveCharacter();
    }

    private void movementInputHandler()
    {
        
        float moveX = 0;
        float moveY = 0;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1;
        }

        // Normalize the input to ensure diagonal movement isn't faster
        movementInput = new Vector2(moveX, moveY).normalized;
    }

    private void MoveCharacter()
    {
        if (rb != null)
        {
            rb.velocity = movementInput * moveSpeed;
        }
        else
        {
            Debug.LogWarning("Rigidbody2D is null, cannot move.");
        }
    }
}
