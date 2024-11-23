using UnityEngine;

public class AOETowerFactory : TowerFactory
{
    private TowerData _towerData;
    public override GameObject CreateTower()
    {
        return _towerData.prefab;
    }

    public override void LoadData()
    {
        _towerData = SetTowerData("AOETower");
    }
}
