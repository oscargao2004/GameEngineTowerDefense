using System;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private Tower _selectedTower;
    private ObserverSubject _subject;
    List<Tower> _towers;

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
        _selectedTower = tower;
        _subject.NotifyListeners(ObserverEvent.TowerSelected);
    }

    public Tower GetSelectedTower()
    {
        return _selectedTower;
    }

    public void ClearSelectedTower()
    {
        _selectedTower = null;
    }

    public void TowerSold()
    {
        _subject.NotifyListeners(ObserverEvent.TowerSell);
    }
}
