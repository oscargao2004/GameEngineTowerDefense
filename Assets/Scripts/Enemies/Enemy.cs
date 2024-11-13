using System;
using System.Linq.Expressions;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected float maxHealth = 100f;
    protected float currentHealth;
    private static Path _path;
    public abstract void Die();
    public abstract void TakeDamage(float damage);

    private float t;
    private void FollowPath()
    {
        GoToNextWaypoint(_path, 0);
    }

    private void GoToNextWaypoint(Path path, int currentPathIndex)
    {
        t += Time.fixedDeltaTime * speed;
        transform.position = Vector3.Lerp(transform.position, path.pointList[currentPathIndex], t/100);

        if (t/100 >= 1)
        {
            GoToNextWaypoint(path, currentPathIndex + 1);
        }
    }


    public virtual void Awake()
    {
        _path = GameObject.Find("Ground").GetComponent<Path>();
        Debug.Log("Enemy initialized");
    }

    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {
        FollowPath();
    }
}
