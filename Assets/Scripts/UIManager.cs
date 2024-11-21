using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton
{
    [SerializeField] Canvas canvas;
    public void EnableUI()
    {
        canvas.gameObject.SetActive(true);
    }
    
}
