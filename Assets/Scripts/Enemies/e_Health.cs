using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_Health : MonoBehaviour
{
	public int scoreReward = 100;
    public int health = 1;
    public GameObject explosionPrefab;
	public GameObject player;
	public bool dead = false;

    public virtual void death() {
        Instantiate(explosionPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
        Destroy(gameObject);
		GameObject.Find("Spawner").GetComponent<o_Spawner>().decreaseMobCount();
		player.GetComponent<p_Score>().addScore(scoreReward);
    }

    public virtual void damage(int dmg) {
        health -= dmg;
        if (health <= 0 && !dead) {
			dead = true;
            death();
        }
    }
}
