using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MonoBehaviour
{
    public int health;
    private Animator animator;
    private bool isHit; // ���� ��� ������������ ��������� ��������� �����
    private Player player;
    public int damageToPlayer = 1;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isHit = false; // ���������� �� ������� ����
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter ������");
    }

    public void TakeDamage(int damage)
    {
        if (!isHit) // ���������, �� ������� �� ��� ����
        {
            isHit = true; // ������������� ����
            animator.SetBool("isHit", true);
            health -= damage;

            StartCoroutine(ResetHitAnimation()); // ��������� �������� ��� ������ ��������
        }
    }

    void Die()
    {
        animator.SetBool("Dead", true);
        StartCoroutine(HandleDeath());
    }

    private IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    private IEnumerator ResetHitAnimation()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("isHit", false);
        isHit = false; // ���������� ����
    }

    public void AttackPlayer()
    {
        if (player != null)
        {
            player.TakeDamage(damageToPlayer); // ������� ���� ������
            Debug.Log("Player took damage: " + damageToPlayer);
        }
    }
}

