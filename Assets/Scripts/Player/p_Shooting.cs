using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_Shooting : MonoBehaviour
{
    public float rpm = 600;
    public Vector3[][] bulletSpawnPositions;
	public int level = 0;
    public GameObject bulletPrefab;
    private float timer;

	void Start() {
		bulletSpawnPositions = new Vector3[5][];
		bulletSpawnPositions[0] = new Vector3[1];
		bulletSpawnPositions[0][0] = new Vector3(0f, 0.55f, 0f);
		bulletSpawnPositions[1] = new Vector3[2];
		bulletSpawnPositions[1][0] = new Vector3(0.2f, 0.35f, 0f);
		bulletSpawnPositions[1][1] = new Vector3(-0.2f, 0.35f, 0f);
		bulletSpawnPositions[2] = new Vector3[3];
		bulletSpawnPositions[2][0] = new Vector3(0f, 0.55f, 0f);
		bulletSpawnPositions[2][1] = new Vector3(0.2f, 0.35f, 0f);
		bulletSpawnPositions[2][2] = new Vector3(-0.2f, 0.35f, 0f);
		bulletSpawnPositions[3] = new Vector3[5];
		bulletSpawnPositions[3][0] = new Vector3(0f, 0.55f, 0f);
		bulletSpawnPositions[3][1] = new Vector3(0.2f, 0.35f, 0f);
		bulletSpawnPositions[3][2] = new Vector3(-0.2f, 0.35f, 0f);
		bulletSpawnPositions[3][3] = new Vector3(0.4f, 0.2f, 0f);
		bulletSpawnPositions[3][4] = new Vector3(-0.4f, 0.2f, 0f);
		bulletSpawnPositions[4] = new Vector3[7];
		bulletSpawnPositions[4][0] = new Vector3(0f, 0.55f, 0f);
		bulletSpawnPositions[4][1] = new Vector3(0.2f, 0.35f, 0f);
		bulletSpawnPositions[4][2] = new Vector3(-0.2f, 0.35f, 0f);
		bulletSpawnPositions[4][3] = new Vector3(0.4f, 0.2f, 0f);
		bulletSpawnPositions[4][4] = new Vector3(-0.4f, 0.2f, 0f);
		bulletSpawnPositions[4][5] = new Vector3(0.65f, 0.15f, 0f);
		bulletSpawnPositions[4][6] = new Vector3(-0.65f, 0.15f, 0f);
	}
    void Update() {
        pewpew();
    }

    void pewpew() {
        if (Input.GetMouseButton(0) && Time.time > timer + 60 / rpm) {
			for (int i = 0; i < bulletSpawnPositions[level].Length; i++) {
				Instantiate(bulletPrefab, transform.position + transform.rotation * bulletSpawnPositions[level][i], transform.rotation);
			}
            // GameObject cache = Instantiate(bulletPrefab, transform.position + transform.up * bulletSpawnOffset, transform.rotation);
            timer = Time.time;
        }
    }
}
