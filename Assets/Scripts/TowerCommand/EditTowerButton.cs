using UnityEngine;

public class EditTowerButton : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ExecuteTowerCommand(TowerCommand towerCommand)
    {
        towerCommand.Execute();
    }
}
