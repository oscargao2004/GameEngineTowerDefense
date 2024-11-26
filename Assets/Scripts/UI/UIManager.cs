using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    private static UIElement towerOptionsUI;
    void Awake()
    {
        towerOptionsUI = GetComponentInChildren<TowerOptionsUI>();
    }

    void Start()
    {
    }

    void Update()
    {

    }


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
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
