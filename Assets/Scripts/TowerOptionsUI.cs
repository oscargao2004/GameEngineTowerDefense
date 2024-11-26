using UnityEngine;

public class TowerOptionsUI : UIElement
{
    private static Tower _selectedTower;

    private TowerCommand _sellCommand = new SellTowerCommand(_selectedTower);
    private TowerCommand _upgradeCommand = new UpgradeTowerCommand(_selectedTower);
    
    void Start()
    {
        Disable();
    }

    void Update()
    {
        
    }

    public void SellTower()
    {
        _sellCommand.Execute();
    }

    public void UpgradeTower()
    {
        _upgradeCommand.Execute();
    }
}
