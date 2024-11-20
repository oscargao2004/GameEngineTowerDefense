using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    [SerializeField] private GridSystem _grid;
    public GameObject towerPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaceTower(WorldSpaceMouse.GetTile().transform.position, towerPrefab);
        }
    }

    void PlaceTower(Vector3 location, GameObject tower)
    {
        location.y += 0.5f;
        GameObject newTower = Instantiate(tower, location, Quaternion.identity);
        GetTowerCount.towers.Add(newTower);

    }
}
