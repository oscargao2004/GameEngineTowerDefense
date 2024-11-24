using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : ObserverSubject
{
    private int _killCount;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateKillCount()
    {
        NotifyListeners(ObserverEvent.EnemyDeath);
        _killCount++;
    }
}
