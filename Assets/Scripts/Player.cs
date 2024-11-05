using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
    public int maxHealth = 3; // ������������ ��������
    private int currentHealth; // ������� ��������

    [Header("Player Animation Srttings")]
    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        animator.SetBool("isHit", true);
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(ResetHitAnimation());
        }
        Debug.Log("������� ��������: " + currentHealth);
    }

    private void Die()
    {
        Debug.Log("�������� �����!");
        // ����� ����� �������� ������ ��� ������ ���������, ��������:
        // - ��������������� �������� ������
        // - ���������� ����������
        // - ������������ ������ � �.�.

        Destroy(gameObject);
    }

    private IEnumerator ResetHitAnimation()
    {
        // ���� ��������� �����, ����� �������� ������ �����������
        yield return new WaitForSeconds(0.5f); // �������� 0.5 �� ������ �����

        animator.SetBool("isHit", false);
    }
}
