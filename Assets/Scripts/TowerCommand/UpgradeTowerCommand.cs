using System.Resources;
using UnityEngine;

public class UpgradeTowerCommand : TowerCommand
{
    public override void Execute(Tower tower)
    {
        tower.Upgrade();
    }
}
