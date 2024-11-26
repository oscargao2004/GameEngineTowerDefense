using System;
using Mono.Cecil;
using TMPro;
using UnityEngine;

public class ResourceUI : UIElement, IListener
{
    [SerializeField] private ObserverSubject resourceManagerSubject;
    private ResourceManager resourceManager;
    TMP_Text tmpText;

    private int _balance = 0;

    private void Awake()
    {
        resourceManager = resourceManagerSubject.GetComponent<ResourceManager>();
        tmpText = GetComponentInChildren<TMP_Text>();
    }

    void Start()
    {
        UpdateBalance(0);
        resourceManagerSubject.AddListener(this);
    }

    void Update()
    {
        
    }

    void UpdateBalance(int number)
    {
        _balance = number;
        tmpText.text = "Balance: " + _balance;
    }

    public void OnNotify(ObserverEvent oEvent)
    {
        if (oEvent == ObserverEvent.BalanceUpdate)
        {
            UpdateBalance(resourceManager.GetBalance());
        }
    }
}
