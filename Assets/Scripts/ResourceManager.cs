using UnityEngine;
using UnityEngine.Serialization;

public class ResourceManager : Singleton<ResourceManager>, IListener
{
    private float _balance;
    [SerializeField] ObserverSubject towerManager;
    
    void Start()
    {
        towerManager.AddListener(this);
    }

    void Update()
    {
        
    }


    public void OnNotify(ObserverEvent oEvent)
    {
        switch (oEvent)
        {
            case ObserverEvent.TowerSell:
                AddBalance(20); //need to change to use tower sell costs
                break;
            case ObserverEvent.TowerUpgrade:
                SubtractBalance(50); //need to change to use tower upgrade costs
                break;
            default:
                Debug.Log("No reaction to observer event");
                break;
        }
    }

    void AddBalance(int amount)
    {
        _balance += amount;
    }

    void SubtractBalance(int amount)
    {
        _balance -= amount;
    }
}
