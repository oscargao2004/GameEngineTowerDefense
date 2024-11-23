using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private List<IEventListener> _listeners = new List<IEventListener>();

    public void AddListener(IEventListener eventListener)
    {
        _listeners.Add(eventListener);
    }

    public void RemoveListener(IEventListener eventListener)
    {
        _listeners.Remove(eventListener);
    }

    public void NotifyListeners()
    {
        foreach (IEventListener listener in _listeners)
        {
            listener.OnNotify();
        }
    }
}
