using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class o_StartSleep : MonoBehaviour
{
    public bool sleepOnAwake = true;

    void Awake() {
        gameObject.SetActive(!sleepOnAwake);
    }
}
