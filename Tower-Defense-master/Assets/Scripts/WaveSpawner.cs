using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
	// Random comment.
	public Transform enemyPrefab;
	public float timeBetweenWaves = 5f;
	public Transform spawnPoint;
	public Text waveCountdown;
	private float countdown = 2f;
	private int waveNumber = 1;

	void Update()
	{
		if(countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
		}

		countdown -= Time.deltaTime;
		waveCountdown.text = Mathf.Floor(countdown).ToString();
	}

	IEnumerator SpawnWave()
	{
		for (int i = 0 ; i < waveNumber ; i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(0.5f);
		}
		waveNumber++;
	}

	void SpawnEnemy()
	{
		Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}
