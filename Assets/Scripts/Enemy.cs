using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject destroyEffect;
    public GameObject bloodSplash;


    void Update()
    {
        if (health <= 0)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Instantiate(bloodSplash, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}

