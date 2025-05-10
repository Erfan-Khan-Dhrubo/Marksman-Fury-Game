using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth;

    public float RemainingHealth
    {
        get
        {
            return currentHealth / maxHealth;
        }
    }

    public bool isInvincible;

    public UnityEvent onDied;
    public UnityEvent onDamage;

    public void TakeDamage(float damageAmount)
    {
        if (currentHealth == 0)
        {
            return;
        }

        if (isInvincible)
        {
            return;
        }
        currentHealth -= damageAmount;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth == 0)
        {
            onDied.Invoke();
        }
        else
        {
            onDamage.Invoke();
        }
    }


    public void AddHealth(float amountToAdd)
    {
        if (currentHealth == maxHealth)
        {
            return;
        }
        
        currentHealth += amountToAdd;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
