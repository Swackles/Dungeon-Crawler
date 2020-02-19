using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public float attackRange = 1f;
    public int damage = 20;
    public LayerMask players;
    public Transform attackPoint;
    public Animator animator;



    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    
    void Attack() {
        // Run attack animation
        animator.SetTrigger("Attack");

        // Detect targets
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, players);

        // Deal damage
        foreach(Collider2D player in hitPlayers) {
            player.GetComponent<Player>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected() {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
