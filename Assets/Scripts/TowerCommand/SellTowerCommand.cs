using UnityEngine;

public class SellTowerCommand : TowerCommand
{
    
    Player _player;
    UIManager _uiManager;
    Tower _tower;
    public SellTowerCommand(Tower tower)
    {
        _tower = tower;
    }
    public override void Execute()
    {
        _tower.Sell();

    }
}
