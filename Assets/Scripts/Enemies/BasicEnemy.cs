using System;
using UnityEngine;

public class BasicEnemy : Enemy
{
    public override void Die()
    {
        Destroy(this.gameObject);
        Debug.Log("AHHHHHHHHHH. Enemy died.");
    }
    

    
}
