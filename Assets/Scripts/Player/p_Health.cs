using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class p_Health : MonoBehaviour
{
	public int health = 3;
	public int maxHealth = 3;
	public int scoreDetractForDamage = 1000;
	public Text hpText;
	public GameObject explosionPrefab;
	public p_Death ded;
	public bool gotDamaged = false;

	void Start() {
		drawHealth();
	}

	void drawHealth() {
		hpText.text = health + " / " + maxHealth;
	}

	public void damage(int damage) {
		if (!gotDamaged) {
			gotDamaged = true;
		}
		health -= damage;
		GetComponent<p_Score>().score -= 1000;
		drawHealth();
		if (health <= 0) {
			death();
		}
	}

	public void heal(int ammount) {
		health = Mathf.Clamp(health + ammount, 0, maxHealth);
		drawHealth();
	}

	void death() {
		Transform cache = Instantiate(explosionPrefab, transform.position, Quaternion.identity).transform;
		cache.localScale = Vector3.one * 2f;
		// Destroy(gameObject);
		ded.death();
		// deathText.gameObject.SetActive(true);
		// Debug.Log("You dieded");
	}
}
