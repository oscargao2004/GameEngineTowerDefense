using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Renderer _renderer;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        /*if (WorldSpaceMouse.GetMouseRayHit().collider.gameObject == this.gameObject)
        {
            _renderer.material.color = Color.red;
        }
        else
        {
            _renderer.material.color = Color.white;

        }
        */
        
    }

    private void OnMouseEnter()
    {
        _renderer.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = Color.white;
    }
}

