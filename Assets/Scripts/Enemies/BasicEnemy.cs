using System;
using UnityEngine;

public class BasicEnemy : Enemy
{
    private EventManager _eventManager;

    protected override void Awake()
    {
        base.Awake();
        _eventManager = GetComponent<EventManager>();

    }

    protected override void Start()
    {
        base.Start();
        _eventManager.AddListener(UITestingScript.Instance);
    }
    public override void Die()
    {
        _eventManager.NotifyListeners();
        Debug.Log("AHHHHHHHHHH. Enemy died.");
        Destroy(this.gameObject);
    }
    

    
}
