using System.Resources;
using UnityEngine;

public class UpgradeTowerCommand : TowerCommand
{
    Player _player;
    Tower _tower;
    public UpgradeTowerCommand(Tower tower)
    {
        _tower = tower;
    }
    public override void Execute()
    {
        _tower.Upgrade();
    }
}
