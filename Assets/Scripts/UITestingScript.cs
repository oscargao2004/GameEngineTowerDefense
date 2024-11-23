using TMPro;
using UnityEngine;

public class UITestingScript : Singleton<UITestingScript>, IEventListener
{
    [SerializeField] private TextMeshProUGUI textMesh;

    private int killCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMesh.text = "Kill Count: " + killCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNotify()
    {
        Debug.Log("UI Notified");
        killCount++;
        textMesh.text = "Kill Count: " + killCount;
    }
}
