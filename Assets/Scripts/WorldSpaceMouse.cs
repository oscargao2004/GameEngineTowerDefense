using System;
using TMPro.EditorUtilities;
using UnityEngine;

public class WorldSpaceMouse : Singleton<WorldSpaceMouse>
{
    [Header("Raycast Settings")]
    [SerializeField] private float maxRayDistance = 20f;
    private Camera _mainCamera;
    private Vector3 _mouseWorldPosition;
    private static RaycastHit _mouseRayHit;
    private Ray _ray;
    public static bool raycastIsColliding;

    [Header("Debug Settings")] 
    [SerializeField] private Color debugColor;
    [SerializeField] private float rayHitPointSphereRadius = 0.2f;

    private ISelectable _selected;

    void Awake()
    {
        _mainCamera = Camera.main;
    }
    void Update()
    {
        Vector3 screenMousePos = Input.mousePosition;
        _mouseWorldPosition = _mainCamera.ScreenToWorldPoint(new Vector3(screenMousePos.x, screenMousePos.y, _mainCamera.nearClipPlane));
        //_ray = new Ray(_mainCamera.transform.position, (_mouseWorldPosition - _mainCamera.transform.position).normalized);
        //_ray = new Ray(_mouseWorldPosition, (_mainCamera.transform.forward).normalized);
        _ray.origin = _mouseWorldPosition;
        _ray.direction = _mainCamera.transform.forward.normalized;

        RaycastHit hit;
        if (Physics.Raycast(_ray, out hit))
        {
            raycastIsColliding = true;
            _mouseRayHit = hit;
        }
        else
        {
            raycastIsColliding = false;
        }
        
        if (raycastIsColliding)
        {
            ISelectable selectable = GetMouseRayHit().transform.GetComponent<ISelectable>();
            if (selectable != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (_selected != null)
                    {
                        //_selected.OnDeselect();
                        _selected = selectable;
                        _selected.OnSelect();
                    }
                    else
                    {
                        _selected = selectable;
                        _selected.OnSelect();
                    }
                }
            }
        }
    }

    public static RaycastHit GetMouseRayHit()
    {
        return _mouseRayHit;
    }

    public static GameObject GetTile()
    {
        return GetMouseRayHit().collider.gameObject;
    }
    
    

    private void OnDrawGizmos()
    {
        debugColor.a = 1f;
        Gizmos.color = debugColor;
        Gizmos.DrawLine(_ray.origin, _mouseRayHit.point);
        Gizmos.DrawSphere(_mouseRayHit.point, rayHitPointSphereRadius);
    }
}
