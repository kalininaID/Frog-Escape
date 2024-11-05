using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MonoBehaviour
{
    public int health;
    private Animator animator;
    private bool isHit; // Флаг для отслеживания состояния получения урона
    private Player player;
    public int damageToPlayer = 1;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isHit = false; // Изначально не получал урон
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
        Debug.Log("OnCollisionEnter вызван");
    }

    public void TakeDamage(int damage)
    {
        if (!isHit) // Проверяем, не получал ли уже урон
        {
            isHit = true; // Устанавливаем флаг
            animator.SetBool("isHit", true);
            health -= damage;

            StartCoroutine(ResetHitAnimation()); // Запускаем корутину для сброса анимации
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
        isHit = false; // Сбрасываем флаг
    }

    public void AttackPlayer()
    {
        if (player != null)
        {
            player.TakeDamage(damageToPlayer); // Наносим урон игроку
            Debug.Log("Player took damage: " + damageToPlayer);
        }
    }
}

