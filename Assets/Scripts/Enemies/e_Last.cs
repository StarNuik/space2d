using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_Last : MonoBehaviour
{
    public o_Spawner spawn;

	void OnDisable() {
		spawn.preWave();
	}
}
