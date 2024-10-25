using UnityEngine;

public class RecallTowerCommand : TowerCommand
{
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
