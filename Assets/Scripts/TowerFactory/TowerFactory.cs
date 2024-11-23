using UnityEngine;


public abstract class TowerFactory
{
    public abstract GameObject CreateTower();

    public abstract void LoadData();

    protected TowerData SetTowerData(string fileName)
    {
        TowerData towerData = Resources.Load<TowerData>($"ScriptableObjects/Towers/" + fileName);
        
        return towerData;
    }
}
