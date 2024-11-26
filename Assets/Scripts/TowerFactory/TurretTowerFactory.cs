using System;
using UnityEngine;

public class TurretTowerFactory : TowerFactory
{
    private static TowerData _towerData;
    public override GameObject CreateTower()
    {
        return _towerData.prefab;
    }

    public override void LoadData()
    {
        _towerData = SetTowerData("TurretTower");
    }
}
