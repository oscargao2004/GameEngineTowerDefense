using UnityEngine;

public class LaserTowerFactory : TowerFactory
{
    private TowerData _towerData;
    public override GameObject CreateTower()
    {
        return _towerData.prefab;
    }

    public override void LoadData()
    {
        _towerData = SetTowerData("LaserTower");
    }
}
