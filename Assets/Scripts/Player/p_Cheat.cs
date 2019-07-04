using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_Cheat : MonoBehaviour
{
	private float timer;

    void Update() {
		if (Input.GetKey(KeyCode.P)) {
			timer = Time.time;
			StartCoroutine("epega");
		}
	}

	void cheat() {
		GetComponent<p_Health>().maxHealth = 250;
		GetComponent<p_Health>().health = 250;
		GetComponent<p_Health>().damage(1);
	}

	IEnumerator epega() {
		while (Time.time < timer + 2f) {
			if (Input.GetKey(KeyCode.E)) {
				timer = Time.time;
				break;
			}
			yield return new WaitForFixedUpdate();
		}
		while (Time.time < timer + 2f) {
			if (Input.GetKey(KeyCode.P)) {
				timer = Time.time;
				break;
			}
			yield return new WaitForFixedUpdate();
		}
		while (Time.time < timer + 2f) {
			if (Input.GetKey(KeyCode.E)) {
				timer = Time.time;
				break;
			}
			yield return new WaitForFixedUpdate();
		}
		while (Time.time < timer + 2f) {
			if (Input.GetKey(KeyCode.G)) {
				timer = Time.time;
				break;
			}
			yield return new WaitForFixedUpdate();
		}
		while (Time.time < timer + 2f) {
			if (Input.GetKey(KeyCode.A)) {
				timer = Time.time;
				cheat();
				break;
			}
			yield return new WaitForFixedUpdate();
		}
	}
}
