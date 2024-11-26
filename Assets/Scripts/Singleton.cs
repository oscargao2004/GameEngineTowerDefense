using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set;}
    
    void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
