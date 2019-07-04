using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_Movement : MonoBehaviour
{
    public float speed = 1f;
	public Vector2 clampX;
	public Vector2 clampY;

    void Update() {
        Vector3 move = getKeys();
        movePlayer(move);
    }

    Vector3 getKeys() {
        Vector3 res = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            res.y++;
        if (Input.GetKey(KeyCode.S))
            res.y--;
        if (Input.GetKey(KeyCode.A))
            res.x--;
        if (Input.GetKey(KeyCode.D))
            res.x++;

        return (res.normalized);
    }

    void movePlayer(Vector3 move) {
        Vector3 old;

        old = transform.position;
        transform.position = old + move * speed * Time.deltaTime;
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, clampX.x, clampX.y), Mathf.Clamp(transform.position.y, clampY.x, clampY.y), transform.position.y);
    }
}
