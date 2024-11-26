using UnityEngine;

public class SellTowerCommand : TowerCommand
{
    public override void Execute(Tower tower)
    {
        tower.Sell();
    }
}
