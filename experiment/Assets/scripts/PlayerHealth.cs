using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float currenthealth;

    public HealthBar healthBar;

    

    void Start()
    {
        currenthealth = health;
        healthBar.SetMaxHealth(health);
    }

    public void TakeDamage(float damage)
    {
        FindObjectOfType<AudioManager>().Play("PlayerHit");
        healthBar.SetHealth(currenthealth);
        currenthealth -= damage;
        if (currenthealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        FindObjectOfType<GameManager>().EndGame();
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        GetComponent<DeathHandler>().HandleDeath();
    }
}
