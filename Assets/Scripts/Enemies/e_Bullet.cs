using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_Bullet : MonoBehaviour
{
    public float speed = 1f;
	public int damage = 1;
	public float timeToDeath = 1.5f;
	private float timer;

	void Start() {
        timer = Time.time;
    }

    void Update() {
        if (Time.time > timer + timeToDeath  || transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 6 || transform.position.y < -6)
            Destroy(gameObject);
    }

    void FixedUpdate() {
        transform.position = transform.position + transform.up * speed * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            col.GetComponent<p_Health>().damage(damage);
            Destroy(gameObject);
        }
    }
}
