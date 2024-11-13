using UnityEngine;

public class BasicEnemy : Enemy
{
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
    
    public override void Die()
    {
        Destroy(this.gameObject);
        Debug.Log("AHHHHHHHHHH. Enemy died.");
    }

    public override void TakeDamage(float damage)
    {
        if (currentHealth <= maxHealth)
        {
            Die();
        }
        else
        {
            currentHealth -= damage;
        }

    }
    
    
}
