using System.Collections.Generic;
using UnityEngine;

public class ProjectileObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject projectilePoolObjPrefab;
    [SerializeField] int initialPoolSize;
    
    Queue<GameObject> _pool = new Queue<GameObject>();
    void Awake()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject projectile = Instantiate(projectilePoolObjPrefab, transform);
            _pool.Enqueue(projectile);
            projectile.SetActive(false);
        }
    }

    void Update()
    {
    }

    public GameObject GetObject()
    {
        GameObject go = _pool.Dequeue();
        go.SetActive(true);
        return go;
    }

    public void ReturnObject(GameObject go)
    {
        _pool.Enqueue(go);
        go.SetActive(false);
    }
}
