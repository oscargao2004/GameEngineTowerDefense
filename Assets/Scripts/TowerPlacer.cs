using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    [SerializeField] private GridSystem _grid;
    [SerializeField] private GameObject parent;
    private TowerFactory _towerFactory;
    private int i;

    private List<TowerFactory> _towerFactories = new List<TowerFactory>
    {
        new TurretTowerFactory(),
        new LaserTowerFactory(),
        new AOETowerFactory()
    };

    void Start()
    {
        foreach (TowerFactory factory in _towerFactories)
        {
            factory.LoadData();
        }
        _towerFactory = _towerFactories[0];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && WorldSpaceMouse.raycastIsColliding)
        {
            SpawnTower(WorldSpaceMouse.GetTile().transform.position, Quaternion.identity);
        }
    }
    
    private void SpawnTower(Vector3 position, Quaternion rotation)
    {
        Instantiate(_towerFactory.CreateTower(), position, rotation, parent.transform);
    }

    public void ChangeTowerType()
    {
        Debug.Log("tower type changed");
        i++;
        if (i >= _towerFactories.Count) i = 0;
        _towerFactory = _towerFactories[i];
    }
}
