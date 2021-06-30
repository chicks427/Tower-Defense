using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 1f;
    [HideInInspector]
	public float speed;
    private float health;
    public float startHealth = 100;
    public int value = 50;
    public GameObject deathEffect;
    public Image healthBar;
    private bool alive;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
        alive = true;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (!alive)
        {
            // Lasers invoke TakeDamage every frame. If things
            // happen too quickly, an enemy can end up calling
            // Die() multiple times, giving extra money/messing 
            // up EnemiesAlive. This prevents that.
            return;
        }

        PlayerStats.Money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);

        alive = false;
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
}
