using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Path path {get; private set;}
    private List<Enemy> _enemyList = new List<Enemy>();
    
    void Start()
    {
        //instantiate enemies on play
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
