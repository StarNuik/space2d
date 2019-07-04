using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class e_Boss : e_Health
{
    public Vector3[] shootPoints;
	public Vector3[] shootAnglesMinMaxDir;
	public float rotationSpeed = 10f;
	public GameObject bulletPrefab;
	public float rpm;
	public GameObject bossText;                  
	public Text bossHealth;
	public o_Spawner spawn;
	private float maxHealth;
	private float timer;
	private float aliveTime;

	void Start() {
		maxHealth = health;
		aliveTime = Time.time;
		drawHealth();
		bossText.SetActive(true);
	}

	void FixedUpdate() {
		if (Time.time > timer + 60 / rpm) {
			shootAll();
			timer = Time.time;
		}
	}

	void shootAll() {
		float t = Time.time;
		for (int i = 0; i < shootPoints.Length; i++) {
			Instantiate(bulletPrefab, shootPoints[i], Quaternion.Euler(0f, 0f, shootAnglesMinMaxDir[i].x + shootAnglesMinMaxDir[i].z * Mathf.PingPong((t - aliveTime) * rotationSpeed, shootAnglesMinMaxDir[i].y)));
		}
	}

	public override void death() {
		bossText.SetActive(false);
		Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		spawn.preWave();
		Destroy(gameObject);
	}

	public override void damage(int dmg) {
		health -= dmg;
		drawHealth();
		if (health <= 0) {
			player.GetComponent<p_Score>().addScore(scoreReward);
			death();
		}
	}

	void drawHealth() {
		bossHealth.text = health + " / " + maxHealth;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			col.gameObject.GetComponent<p_Health>().damage(3);
		}
	}
}
