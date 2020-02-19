using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
        if (movement.x == 1) {
            // Right
            animator.SetFloat("Idle", 0.3f);
        } else if (movement.x == -1) {
            // Left
            animator.SetFloat("Idle", 0.2f);
        } else if (movement.y == 1) {
            // Back
            animator.SetFloat("Idle", 0.1f);
        } else if (movement.y == -1) {
            // Front
            animator.SetFloat("Idle", 0f);
        }
    }
}
