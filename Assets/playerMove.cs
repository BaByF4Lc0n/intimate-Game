using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public Rigidbody2D body;

    float horizontal;
    float vertical;
    public Animator animator;
    public float runSpeed = 5f;
    Vector2 movement;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from keyboard
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Update movement vector based on input
        movement = new Vector2(horizontal, vertical).normalized;

        // Set animator parameters
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // Move the character based on the calculated movement vector
        body.velocity = movement * runSpeed;
    }
}
