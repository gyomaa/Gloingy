using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100f;
    public float currenthealth;

    public HealthBar healthBar;

    void Start()
    {
        currenthealth = health;
        healthBar.SetMaxHealth(health);
    }

    public void TakeDamage(float amount)
    {
        FindObjectOfType<AudioManager>().Play("HitMarker");
        healthBar.SetHealth(currenthealth);
        currenthealth -= amount;
        if (currenthealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
