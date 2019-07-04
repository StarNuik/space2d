using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class p_Death : MonoBehaviour
{
	public Text deathText;
	public Text scoreText;
	public Text restartText;
	public GameObject hpObj;
	public GameObject scoreObj;
	public GameObject player;
	public float waitForRestart = 3f;
	private float timer;
	private bool called = false;

    public void death() {
		player.SetActive(false);
		timer = Time.time;
		called = true;
		deathText.gameObject.SetActive(true);
		scoreObj.gameObject.SetActive(false);
		hpObj.gameObject.SetActive(false);
	}

	void Update() {
		if (called && Time.time > timer + waitForRestart) {
			scoreText.gameObject.SetActive(true);
			restartText.gameObject.SetActive(true);
			scoreText.text = "Your score: " + player.GetComponent<p_Score>().score.ToString("0000000");
			if (Input.GetKey(KeyCode.Space)) {
				SceneManager.LoadScene(0);
			}
		}
	}
}
