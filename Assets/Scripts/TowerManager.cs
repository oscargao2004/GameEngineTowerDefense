using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private Tower _selectedTower;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetSelectedTower(Tower tower)
    {
        _selectedTower = tower;
    }

    public Tower GetSelectedTower()
    {
        return _selectedTower;
    }

    void ClearSelectedTower()
    {
        _selectedTower = null;
    }
}
