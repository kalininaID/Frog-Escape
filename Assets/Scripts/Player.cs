using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
    public int maxHealth = 3; // ћаксимальное здоровье
    private int currentHealth; // “екущее здоровье

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
        Debug.Log("“екущее здоровье: " + currentHealth);
    }

    private void Die()
    {
        Debug.Log("ѕерсонаж погиб!");
        // «десь можно добавить логику дл€ смерти персонажа, например:
        // - воспроизведение анимации смерти
        // - отключение управлени€
        // - перезагрузка уровн€ и т.д.

        Destroy(gameObject);
    }

    private IEnumerator ResetHitAnimation()
    {
        // ∆дем некоторое врем€, чтобы анимаци€ успела проигратьс€
        yield return new WaitForSeconds(0.5f); // «амените 0.5 на нужное врем€

        animator.SetBool("isHit", false);
    }
}
