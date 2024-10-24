using UnityEngine;

public class RecallTowerCommand : TowerCommand
{
    UIManager _uiManager;
    Tower _tower;
    public RecallTowerCommand(Tower tower)
    {
        _tower = tower;
    }
    public override void Execute()
    {
        _tower.Recall();
    }
}
