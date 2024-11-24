using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UITestingScript : Singleton<UITestingScript>, IListener
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private ObserverSubject observerSubject;

    private int killCount = 0;
    void Start()
    {
        observerSubject.AddListener(this as IListener);
        textMesh.text = "Kill Count: " + killCount;
    }

    public void OnNotify(ObserverEvent oEvent)
    {
        Debug.Log("UI Notified");
        if (oEvent == ObserverEvent.EnemyDeath)
        {
            killCount++;
            textMesh.text = "Kill Count: " + killCount;
        }
    }
}
