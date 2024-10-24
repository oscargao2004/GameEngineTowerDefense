using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton
{
    [SerializeField] Tower selectedTower;
    [SerializeField] List<EditTowerButton> editTowerButtons;
    TowerCommand _upgradeCommand, _sellCommand, _recallCommand; 

    void Start()
    {
        _upgradeCommand = new UpgradeTowerCommand(selectedTower);
        _sellCommand = new SellTowerCommand(selectedTower);
        _recallCommand = new RecallTowerCommand(selectedTower);

       
        editTowerButtons[0].GetComponent<Button>().onClick.AddListener(() => editTowerButtons[0].ExecuteTowerCommand(_upgradeCommand));
        editTowerButtons[1].GetComponent<Button>().onClick.AddListener(() => editTowerButtons[1].ExecuteTowerCommand(_sellCommand));
        editTowerButtons[2].GetComponent<Button>().onClick.AddListener(() => editTowerButtons[2].ExecuteTowerCommand(_recallCommand));
    }

    void Update()
    {
        
    }
    
}
