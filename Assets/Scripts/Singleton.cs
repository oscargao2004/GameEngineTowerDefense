using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set;}
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
