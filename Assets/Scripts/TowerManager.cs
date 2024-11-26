using System;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private Tower _selectedTower;
    private ObserverSubject _subject;

    private void Awake()
    {
        _subject = GetComponent<ObserverSubject>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetSelectedTower(Tower tower)
    {
        _subject.NotifyListeners(ObserverEvent.TowerSelected);
        _selectedTower = tower;
    }

    public Tower GetSelectedTower()
    {
        return _selectedTower;
    }

    public void ClearSelectedTower()
    {
        _selectedTower = null;
    }
}
