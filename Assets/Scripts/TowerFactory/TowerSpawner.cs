using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner
{
    private TowerFactory _towerFactory = new TurretTowerFactory();

    public void SpawnTower(Vector3 position, Quaternion rotation)
    {
        Object.Instantiate(_towerFactory.CreateTower(), position, rotation);
    }
}
