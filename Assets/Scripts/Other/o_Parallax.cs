using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class o_Parallax : MonoBehaviour
{
    public GameObject player;
	public GameObject[] target;
	public float[] smooth;
	private Vector3[] origin;

	void Start() {
		origin = new Vector3[target.Length];
		for (int i = 0; i < target.Length; i++) {
			origin[i] = target[i].transform.position;
		}
	}

	void Update() {
		Vector3 diff = player.transform.position;
		for (int i = 0; i < target.Length; i++) {
			target[i].transform.position = origin[i] + diff / smooth[i];
		}
	}
}
