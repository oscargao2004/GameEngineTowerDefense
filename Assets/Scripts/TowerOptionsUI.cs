using UnityEngine;

public class TowerOptionsUI : UIElement, IListener
{
    [SerializeField] private ObserverSubject towerManager;
    private Tower _selectedTower;

    private TowerCommand _sellCommand = new SellTowerCommand();
    private TowerCommand _upgradeCommand = new UpgradeTowerCommand();
    
    TowerFactory turretFactory = new TurretTowerFactory();
    TowerFactory laserFactory = new LaserTowerFactory();
    TowerFactory aoeFactory = new AOETowerFactory();
    
    void Start()
    {
        turretFactory.LoadData();
        laserFactory.LoadData();
        aoeFactory.LoadData();
        towerManager.AddListener(this);
        Disable();
    }

    void Update()
    {
        
    }
    public void SwitchToTurret()
    {
        SwitchTowerType(turretFactory);
    }
    public void SwitchToLaser()
    {
        SwitchTowerType(laserFactory);
    }
    public void SwitchToAoe()
    {
        SwitchTowerType(aoeFactory);
    }
    
    public void SwitchTowerType(TowerFactory factory)
    {
        GameObject newTower = Instantiate(factory.CreateTower(), _selectedTower.transform.position, Quaternion.identity);
        Destroy(_selectedTower.gameObject);
        _selectedTower = newTower.GetComponent<Tower>();
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
