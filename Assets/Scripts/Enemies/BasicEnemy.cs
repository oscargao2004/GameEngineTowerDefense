using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BasicEnemy : Enemy
{

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }
    protected override void Die()
    {
        base.Die();
        Debug.Log("AHHHHHHHHHH. Enemy died.");
        Destroy(this.gameObject);
    }
    

    
}
