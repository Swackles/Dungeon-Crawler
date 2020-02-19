using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    int currentHealth;
    public Animator animator;
    public Transform player;
    public Transform attackPoint;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector2 direction = player.position - transform.position;

        direction.Normalize();

        movement = direction;

        if (movement.x == 1) {
            animator.SetFloat("Idle", 0.3f);
        } else if (movement.x == -1) {
            animator.SetFloat("Idle", 0.2f);
        } else if (movement.y == 1) {
            animator.SetFloat("Idle", 0.1f);
        } else if (movement.y == -1) {
            animator.SetFloat("Idle", 0f);
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }   

    public void FixedUpdate() {
        MoveCharacter(movement);
    }

    private void MoveCharacter(Vector2 direction) {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.fixedDeltaTime));
    }
}
