using UnityEngine;
using UnityEngine.Serialization;

public class ResourceManager : Singleton<ResourceManager>, IListener
{
    private int _balance;
    [SerializeField] ObserverSubject towerManager;
    private ObserverSubject _subject;

    void Awake()
    {
        _subject = GetComponent<ObserverSubject>();
    }
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
                break;
        }
    }

    void AddBalance(int amount)
    {
        _balance += amount;
        _subject.NotifyListeners(ObserverEvent.BalanceUpdate);
    }

    void SubtractBalance(int amount)
    {
        _balance -= amount;
        _subject.NotifyListeners(ObserverEvent.BalanceUpdate);
    }

    public int GetBalance()
    {
        return _balance;
    }
}
