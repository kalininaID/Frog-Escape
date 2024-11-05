using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MonoBehaviour
{
    public int health;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void Die()
    {
        animator.SetBool("Dead", true);
        // ��������� �������� ��� �������� ������� ����� ���������� ��������
        StartCoroutine(HandleDeath());
    }

    private IEnumerator HandleDeath()
    {
        // ���� ���������� �������� ������
        // ������������, ��� �������� ������ ������ 2 �������
        // �� ������ �������� 2.0f �� ������������ ����� ��������
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}

