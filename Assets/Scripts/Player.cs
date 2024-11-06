using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
    public int maxHealth = 3;

    public GemsManager gemsManager;
    public HealthManager healthManager;

    [Header("Player Animation Srttings")]
    public Animator animator;

    void Start()
    {
        healthManager.healthCount = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        animator.SetBool("isHit", true);
        healthManager.healthCount -= damage;

        if (healthManager.healthCount <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(ResetHitAnimation());
        }
    }

    private void Die()
    {
        Debug.Log("Персонаж погиб!");
        // - воспроизведение анимации смерти
        // - отключение управления
        // - перезагрузка уровня и т.д.

        Destroy(gameObject);
    }

    private IEnumerator ResetHitAnimation()
    {
        // Ждем некоторое время, чтобы анимация успела проиграться
        yield return new WaitForSeconds(0.5f); // Замените 0.5 на нужное время

        animator.SetBool("isHit", false);
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.gameObject.CompareTag("Gems"))
        {
            Destroy(other.gameObject);
            gemsManager.gemCount++;
        }

        if (other.gameObject.CompareTag("Health"))
        {
            if (healthManager.healthCount < maxHealth) 
            { 
                healthManager.healthCount++;
            }
            Destroy(other.gameObject);
        }
    }
}
