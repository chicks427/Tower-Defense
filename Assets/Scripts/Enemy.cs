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

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
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
        PlayerStats.Money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);

        WaveSpawner.EnemiesAlive--;
        Debug.Log("EEEE");
        Debug.Log(WaveSpawner.EnemiesAlive);

        Destroy(gameObject);
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
}
