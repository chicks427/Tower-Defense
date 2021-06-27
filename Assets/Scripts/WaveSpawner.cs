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
		Wave wave = waves[waveIndex];

		for (int i = 0 ; i < wave.count ; i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}
		waveIndex++;
		PlayerStats.Rounds++;

		if (waveIndex == waves.Length)
		{
			Debug.Log("Reached the final wave");
			this.enabled = false;
		}
	}

	void SpawnEnemy(GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
		EnemiesAlive++;
	}
}
