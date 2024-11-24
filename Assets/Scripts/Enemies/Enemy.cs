using System;
using System.Linq.Expressions;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] public float speed = 1f;
    [SerializeField] protected float maxHealth = 100f;
    protected float currentHealth;
    protected EnemyManager enemyManager;

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        enemyManager.UpdateKillCount();
    }

    protected virtual void Awake()
    {
        enemyManager = GetComponentInParent<EnemyManager>();
    }

    protected virtual void Start()
    {
        Debug.Log("Enemy initialized");
        currentHealth = maxHealth;
    }

    protected virtual void Update()
    {
        
    }

}
