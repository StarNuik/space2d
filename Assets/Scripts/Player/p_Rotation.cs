using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_Rotation : MonoBehaviour
{
    public Camera cam;
	private float lastFrameRot;
	public float rotationThreshold = 5f;
	public Sprite original;
	public Sprite rotating;
	private SpriteRenderer sr;

	void Start() {
		lastFrameRot = 0f;
		sr = GetComponentInChildren<SpriteRenderer>();
	}

    void Update() {
        rotateToMouse();
    }

    void rotateToMouse() {
        Vector3 mousePos = Vector3.zero;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
		if (transform.rotation.eulerAngles.z - lastFrameRot > rotationThreshold) {
			sr.sprite = rotating;
			sr.flipX = false;
		} else if (transform.rotation.eulerAngles.z - lastFrameRot < -rotationThreshold) {
			sr.sprite = rotating;
			sr.flipX = true;
		} else {
			sr.sprite = original;
			sr.flipX = false;
		}
		lastFrameRot = transform.rotation.eulerAngles.z;
    }
}
