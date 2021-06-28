using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
	public static int EnemiesAlive = 0;
	public Transform enemyPrefab;
	public float timeBetweenWaves = 5f;
	public Transform spawnPoint;
	public Text waveCountdown;
	private float countdown = 2f;
	private int waveIndex = 0;
	public Wave[] waves;
	public GameManager gameManager;

	void Update()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}

		if (waveIndex >= waves.Length && EnemiesAlive == 0)
		{
			gameManager.WinLevel();
			this.enabled = false;
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
		PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];

		EnemiesAlive = wave.count;

		for (int i = 0 ; i < wave.count ; i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}

		waveIndex++;
	}

	void SpawnEnemy(GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
	}
}
