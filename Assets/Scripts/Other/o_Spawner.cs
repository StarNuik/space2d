using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class o_Spawner : MonoBehaviour
{
	public Vector3[] spawnPoints;
	public float spawnRandom = 2f;
	public int waveCount = 50;
	public float timeBetweenWaves = 1f;
	public GameObject[] mobPrefabs;
	// public GameObject suicidePrefab;
    public AnimationCurve suicideCurve;
	// public Vector2 suicideMinMax;
	// public GameObject fighterPrefab;
	public AnimationCurve fighterCurve;
	// public Vector2 fighterMinMax;
	// public GameObject machinegunPrefab;
	public AnimationCurve machinegunCurve;
	// public Vector2 machinegunMinMax;
	// public GameObject minibossPrefab;
	public AnimationCurve minibossCurve;
	// public Vector2 minibossMinMax;	
	public AnimationCurve timeBetweenMobs;
	public int bossAfterEvery = 5;
	public GameObject[] bossPrefabs;
	public Text waveText;
	public float waveShow = 3f;
	public GameObject[] pickupPrefabs;
	public Vector3[] pickupSpawnPoint;
	public GameObject player;
	public GameObject winText;
	public GameObject perfectText;
	public GameObject startText;
	public int spawnHealthEvery = 3;
	public Text mobText;

	private int currentWave = -1;
	// private int nextBoss = 0;
	private int[] enemyAmmounts;
	private float waitTime;
	private bool lastLevel = false;
	public int mobCount;

	void Start() {
		enemyAmmounts = new int[5];
	}

	void FixedUpdate() {
		if (startText.activeSelf) {
			if (Input.GetKey(KeyCode.Space)) {
				startText.SetActive(false);
				preWave();
			}
		}
	}

	IEnumerator waitForWave() {
		while (true) {
			if (mobCount <= 0) {
				yield return new WaitForSeconds(timeBetweenWaves);
				preWave();
				break;
			} else {
				yield return new WaitForSeconds(.2f);
			}
		}
	}

	public void preWave() {
		currentWave++;
		if (currentWave % spawnHealthEvery == 0 && currentWave > 0) {
			spawnHealth();
		}
		if (currentWave >= waveCount) {
			mobText.gameObject.SetActive(false);
			winScreen();
		}
		else if (currentWave > 0 && currentWave % bossAfterEvery == 0 && bossPrefabs[currentWave / bossAfterEvery - 1]) {
			mobText.gameObject.SetActive(false);
			startBoss();
		}
		else {
			mobText.gameObject.SetActive(true);
			enemyAmmounts[0] = (int)suicideCurve.Evaluate((float)currentWave / (float)waveCount);
			enemyAmmounts[1] = (int)fighterCurve.Evaluate((float)currentWave / (float)waveCount);
			enemyAmmounts[2] = (int)machinegunCurve.Evaluate((float)currentWave / (float)waveCount);
			enemyAmmounts[3] = (int)minibossCurve.Evaluate((float)currentWave / (float)waveCount);
			mobCount = enemyAmmounts[0] + enemyAmmounts[1] + enemyAmmounts[2] + enemyAmmounts[3];
			drawMobs();
			waitTime = timeBetweenMobs.Evaluate((float)currentWave / (float)waveCount);
			// Debug.Log("| Count: " + mobCount + "| Eval: " + (float)currentWave / (float)waveCount + " | Time: " + waitTime + " |");
			if (currentWave % bossAfterEvery == bossAfterEvery - 1) {
				spawnPickup();
			}
			startWave();
		}
	}

	void spawnPickup() {
		Instantiate(pickupPrefabs[1], pickupSpawnPoint[1], Quaternion.identity);
	}

	void spawnHealth() {
		Instantiate(pickupPrefabs[0], pickupSpawnPoint[0], Quaternion.identity);
	}

	void winScreen() {
		player.GetComponent<p_Health>().ded.scoreObj.SetActive(false);
		player.GetComponent<p_Health>().ded.hpObj.gameObject.SetActive(false);
		if (!player.GetComponent<p_Health>().gotDamaged) {
			perfectText.SetActive(true);
		}
		winText.SetActive(true);
		Destroy(player);
	}

	void startBoss() {
		waveText.text = "Boss wave " + (currentWave / bossAfterEvery - 1);
		StartCoroutine("text");
		Instantiate(bossPrefabs[currentWave / bossAfterEvery - 1]);
	}

	void startWave() {
		waveText.text = "Wave " + (currentWave + 1);
		StartCoroutine("wave");
		StartCoroutine("text");
	}

	void drawMobs() {
		mobText.text = "Mobs left: " + mobCount;
	}

	public void decreaseMobCount() {
		mobCount--;
		drawMobs();
	}

	IEnumerator text() {
		waveText.gameObject.SetActive(true);
		yield return new WaitForSeconds(waveShow);
		waveText.gameObject.SetActive(false);
	}

	IEnumerator wave() {
		while (enemyAmmounts[0] > 0 || enemyAmmounts[1] > 0 || enemyAmmounts[2] > 0 || enemyAmmounts[3] > 0) {
			// int max = 0;
			int type = Random.Range(0, 4);
			// Debug.Log("I want to spawn type: " + type);
			if (enemyAmmounts[type] <= 0) {
				continue;
			}
			GameObject prefab = mobPrefabs[type];
			// Debug.Log("I decided on: " + type);
			enemyAmmounts[type]--;
			GameObject cache = Instantiate(prefab, spawnPoints[Random.Range(0, spawnPoints.Length)] + new Vector3(Random.Range(-spawnRandom, spawnRandom), Random.Range(-spawnRandom, spawnRandom), 0f), Quaternion.identity);
			if ((enemyAmmounts[0] + enemyAmmounts[1] + enemyAmmounts[2] + enemyAmmounts[3]) == 0) {
				break;
			}
			yield return new WaitForSeconds(waitTime);
		}
		// yield return new WaitForSeconds(timeBetweenWaves);
		// preWave();
		StartCoroutine("waitForWave");
	}
}
