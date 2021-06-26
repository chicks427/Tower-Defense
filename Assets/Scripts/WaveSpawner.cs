using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
	public static EnemiesAlive = 0;
	public Transform enemyPrefab;
	public float timeBetweenWaves = 5f;
	public Transform spawnPoint;
	public Text waveCountdown;
	private float countdown = 2f;
	private int waveNumber = 1;

	void Update()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}

		if(countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;
		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
		waveCountdown.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave()
	{
		for (int i = 0 ; i < waveNumber ; i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(0.5f);
		}
		waveNumber++;
		PlayerStats.Rounds++;
	}

	void SpawnEnemy()
	{
		Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
		EnemiesAlive++;
	}
}
