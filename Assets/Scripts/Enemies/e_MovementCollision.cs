using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_MovementCollision : MonoBehaviour
{
    public float speed = 1f;
    public GameObject targetPlayer;

    void Update() {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPlayer.transform.position - transform.position);
    }

    void FixedUpdate() {
        Vector3 dir = targetPlayer.transform.position - transform.position;
        transform.position = transform.position + dir.normalized * speed * Time.fixedDeltaTime;
    }

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			col.gameObject.GetComponent<p_Health>().damage(1);
			GetComponent<e_Health>().damage(1);
		}
	}
}
