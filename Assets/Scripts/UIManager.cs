using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton
{
    //mostly temporary code in order for the command pattern to work
    Tower activeTower;
    [SerializeField] GameObject towerPrefab;
    [SerializeField] List<EditTowerButton> editTowerButtons;
    TowerCommand _upgradeCommand, _sellCommand, _recallCommand; 

    void Start()
    {
        activeTower = FindAnyObjectByType<Tower>();
        editTowerButtons[0].GetComponent<Button>().onClick.AddListener(() => editTowerButtons[0].ExecuteTowerCommand(_upgradeCommand));
        editTowerButtons[1].GetComponent<Button>().onClick.AddListener(() => editTowerButtons[1].ExecuteTowerCommand(_sellCommand));
        editTowerButtons[2].GetComponent<Button>().onClick.AddListener(() => editTowerButtons[2].ExecuteTowerCommand(_recallCommand));
    }

    void Update()
    {
    }

    public void SpawnTower()
    {
        GameObject newTower = Instantiate(towerPrefab);
        activeTower = newTower.GetComponent<Tower>();
        _upgradeCommand = new UpgradeTowerCommand(activeTower);
        _sellCommand = new SellTowerCommand(activeTower);
        _recallCommand = new RecallTowerCommand(activeTower);
    }
    
}
