using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;

    public void Start()
    {
        Destroy(gameObject, 2f);
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthController healthController = collision.GetComponent<HealthController>();
        if (healthController != null && !collision.CompareTag("Player"))
        {
            // Apply damage to the HealthController
            healthController.TakeDamage(damage);

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
