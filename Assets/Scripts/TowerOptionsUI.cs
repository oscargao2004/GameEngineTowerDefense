using UnityEngine;

public class TowerOptionsUI : UIElement, IListener
{
    [SerializeField] private ObserverSubject towerManager;
    private Tower _selectedTower;

    private TowerCommand _sellCommand = new SellTowerCommand();
    private TowerCommand _upgradeCommand = new UpgradeTowerCommand();
    
    void Start()
    {
        towerManager.AddListener(this);
        Disable();
    }

    void Update()
    {
        
    }

    public void SellTower()
    {
        _sellCommand.Execute(_selectedTower);
    }

    public void UpgradeTower()
    {
        _upgradeCommand.Execute(_selectedTower);
    }

    public void OnNotify(ObserverEvent oEvent)
    {
        if (oEvent == ObserverEvent.TowerSelected)
        {
            _selectedTower = towerManager.GetComponent<TowerManager>().GetSelectedTower();
        }
        
    }
}
