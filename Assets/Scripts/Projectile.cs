using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float disableAfterSeconds;
    [SerializeField] float speed;
    public float Damage { get; private set; }
    Rigidbody rb;
    private float timer = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward.normalized * speed;
    }
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= disableAfterSeconds)
        {
            timer = 0;
            Destroy(gameObject); //change logic to utilize object pooling later
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
