using System;
using System.Linq.Expressions;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] public float speed = 1f;
    [SerializeField] protected float maxHealth = 100f;
    protected float currentHealth;

    public abstract void Die();
    
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Awake()
    {
        
        Debug.Log("Enemy initialized");
    }

    public virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void Update()
    {
        
    }
}
