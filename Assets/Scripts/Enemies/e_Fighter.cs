using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_Fighter : MonoBehaviour
{
    public float speed = 1f;
    public GameObject targetPlayer;
	public float distanceFromPlayer = 10f;
	public float rotSpeed = 0.8f;
	private Vector3 moveTarget = Vector3.zero;
	private float startTime;

	void Start() {
		startTime = Time.time;
	}

    void Update() {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPlayer.transform.position - transform.position);
    }

    void FixedUpdate() {
		setTarget();
        Vector3 dir = moveTarget - transform.position;
        transform.position = transform.position + dir.normalized * speed * Time.fixedDeltaTime;
    }

	void setTarget() {
		Vector3 dir = Vector3.up * distanceFromPlayer;
		moveTarget = targetPlayer.transform.position + Quaternion.AngleAxis((Time.time - startTime) * rotSpeed, Vector3.forward) * dir;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			col.gameObject.GetComponent<p_Health>().damage(1);
			GetComponent<e_Health>().damage(1);
		}
	}
}
