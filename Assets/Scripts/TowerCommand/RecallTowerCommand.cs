using UnityEngine;

public class RecallTowerCommand : TowerCommand
{
    public override void Execute(Tower tower)
    {
        tower.Recall();
    }
}
