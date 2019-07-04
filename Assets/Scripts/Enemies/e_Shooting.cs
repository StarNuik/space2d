using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_Shooting : MonoBehaviour
{
    public Vector3[] shootPoints;
	public float rpm = 60f;
	public float pointDiff = 0f;
	public GameObject bulletPrefab;
	private float timer;

	void Update() {
		if (Time.time > timer + 60 / rpm && transform.position.x >= -9 && transform.position.x <= 9 && transform.position.y >= -5 && transform.position.y <= 5) {
			StartCoroutine("shootAll");
            timer = Time.time;
		}
	}

	IEnumerator shootAll() {
		for (int i = 0; i < shootPoints.Length; i++) {
			Instantiate(bulletPrefab, transform.position + transform.rotation * shootPoints[i], transform.rotation);
			yield return new WaitForSeconds(pointDiff);
		}
	}
}
