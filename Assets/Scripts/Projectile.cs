using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float disableAfterSeconds;
    [SerializeField] float speed;
    [SerializeField] ProjectileObjectPool pool;
    public float Damage { get; private set; }
    private Rigidbody rb;
    private float timer = 0f;
    private Vector3 _direction;
    void Awake()
    {
        pool = GameObject.Find("ProjectilePool").GetComponent<ProjectileObjectPool>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= disableAfterSeconds)
        {
            timer = 0;
            pool.ReturnObject(gameObject);
        }
    }

    public void SetPositionDestination(Vector3 position, Vector3 destination)
    {
        transform.position = position;
        _direction = destination - transform.position;
        rb.linearVelocity = _direction * speed;
    }
    public void SetDamage(float damage) {Damage = damage;}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(Damage);
        }
    }
}