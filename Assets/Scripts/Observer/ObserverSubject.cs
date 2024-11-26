using System;
using System.Collections.Generic;
using UnityEngine;

public class ObserverSubject : MonoBehaviour
{
    private List<IListener> _listeners = new List<IListener>();

    public void AddListener(IListener listener)
    {
        _listeners.Add(listener);
    }

    public void RemoveListener(IListener listener)
    {
        _listeners.Remove(listener);
    }

    public void NotifyListeners(ObserverEvent oEvent)
    {
        Debug.Log("Notifying listeners");
        foreach (IListener listener in _listeners)
        {
            listener.OnNotify(oEvent);
        }
    }
}
