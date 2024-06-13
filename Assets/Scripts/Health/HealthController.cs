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

    public UnityEvent OnDamaged;

    public UnityEvent OnDied;

    public UnityEvent OnHealthChanged;

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
            OnHealthChanged.Invoke();
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float health)
    {

        if (currentHealth == maxHealth) 
        {
            return;
        }

        currentHealth += health;

        OnHealthChanged.Invoke();

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
