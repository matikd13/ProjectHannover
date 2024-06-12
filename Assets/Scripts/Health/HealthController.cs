using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;

    public float RemainingHealthPercentage
    {
        get
        {
            return currentHealth / maxHealth;
        }
    }

    public bool isInvincible { get; set; }

    public UnityEvent onDamaged;

    public UnityEvent OnDied;

    public void TakeDamage(float damage)
    {
        if (currentHealth == 0)
        {
            return;
        }
        
        if (isInvincible)
        {
            return;
        }

        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth == 0)
        {
            OnDied.Invoke();
        }
        else
        {
            onDamaged.Invoke();
        }
    }

    public void AddHealth(float health)
    {

        if (currentHealth == maxHealth) 
        {
            return;
        }

        currentHealth += health;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
