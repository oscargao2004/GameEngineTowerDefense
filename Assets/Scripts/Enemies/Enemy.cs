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

    [SerializeField]
    [Range(0f, 1f)]
    private float t;

    private int _pathIndex = 0;
    private void FollowPath()
    {
        GoToNextWaypoint(_path);
    }

    private void GoToNextWaypoint(Path path)
    {
        transform.position = Vector3.Lerp(path.pointList[0], path.pointList[1], t);
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    public virtual void Awake()
    {
        _path = GameObject.Find("Ground").GetComponent<Path>();
        Debug.Log("Enemy initialized");
    }

    public virtual void Start()
    {
        transform.position = _path.pointList[0];
        currentHealth = maxHealth;
    }

    public virtual void Update()
    {
        FollowPath();
        
    }
}
