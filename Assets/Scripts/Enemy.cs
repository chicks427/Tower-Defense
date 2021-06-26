using UnityEngine;
>GPUs are going to be so fucking cheap
 <= 0)
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

        Destroy(gameObject);
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
}
