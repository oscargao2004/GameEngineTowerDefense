using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float disableAfterSeconds;
    [SerializeField] float speed;
    [SerializeField] ProjectileObjectPool pool;
    public float Damage { get; private set; }
    Rigidbody rb;
    private float timer = 0f;
    void Start()
    {
        pool = GameObject.Find("ProjectilePool").GetComponent<ProjectileObjectPool>();
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward.normalized * speed;
    }
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= disableAfterSeconds)
        {
            timer = 0;
            pool.ReturnObject(gameObject);
        }
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
