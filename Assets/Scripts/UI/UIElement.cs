using UnityEngine;

public abstract class UIElement : MonoBehaviour
{
    private bool _isActive = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Enable()
    {
        gameObject.SetActive(true);
        _isActive = true;
    }
    public void Disable()
    {
        gameObject.SetActive(false);
        _isActive = false;
    }

}
