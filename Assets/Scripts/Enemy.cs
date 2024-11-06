using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private Player player;

    public int health;
    private bool isHit;
    private bool isDead;
    
    public int damageToPlayer = 1;
    public float attackCooldown = 1f;
    private bool canAttack = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isHit = false;
    }

    void Update()
    {
        if (health <= 0)
        {
            isDead = true;
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isHit) 
        {
            Debug.Log(123);
            isHit = true;
            animator.SetTrigger("isHit");
            health -= damage;

            StartCoroutine(ResetHitAnimation()); 
        }
    }

    void Die()
    {
        animator.SetBool("Dead", true);
        StartCoroutine(HandleDeath());
    }

    private void Attack(Player player)
    {
        canAttack = false; 
        animator.SetTrigger("Attack"); 
        player.TakeDamage(damageToPlayer);
        StartCoroutine(AttackCooldown());
    }


    private IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    private IEnumerator ResetHitAnimation()
    {
        yield return new WaitForSeconds(1f);
        isHit = false;
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && canAttack)
        {
            Player player = collision.collider.GetComponent<Player>();
            if (player != null && !isDead)
            {
                Attack(player);
            }
        }
    }

}

