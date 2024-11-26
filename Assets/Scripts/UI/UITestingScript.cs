using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UITestingScript : Singleton<UITestingScript>
{
    private static UIElement towerOptionsUI;
    void Awake()
    {
        towerOptionsUI = GetComponentInChildren<TowerOptionsUI>();
    }

    void Start()
    {
    }

    public static void Toggle(UIType uiType, bool value)
    {
        switch (uiType)
        {
            case UIType.TowerOptionsUI:
                towerOptionsUI.gameObject.SetActive(value);
                break;
        }
    }
}
    
