using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class o_Pickup : MonoBehaviour
{
    public bool levelUp;
	public bool heal;
	public float startSpeed = 3f;
	public float drag = 0.25f;
	private float currentSpeed;

	void Start() {
		currentSpeed = startSpeed;
	}

	void FixedUpdate() {
		transform.position = transform.position + new Vector3(0f, currentSpeed * Time.fixedDeltaTime * -1f, 0f);
		currentSpeed = Mathf.Clamp(currentSpeed - drag * Time.fixedDeltaTime, 0f, startSpeed);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			if (levelUp) {
				col.gameObject.GetComponent<p_Shooting>().level = Mathf.Clamp(col.gameObject.GetComponent<p_Shooting>().level + 1, 0, 4);
			}
			if (heal) {
				col.gameObject.GetComponent<p_Health>().heal(5);
			}
			Destroy(gameObject);
		}
	}
}
