using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {
    private Vector3[] map = new Vector3[] {
        new Vector3(-1.25f, -1.25f, 0),
        new Vector3(1.25f, 0.75f, 0),
        new Vector3(-1.25f, 2.75f, 0)
    };

    // Use this for initialization
    void Start() {
        for (int i = 0; i < map.Length; i++) {
            Instantiate(Resources.Load("Bar"), map[i], Quaternion.Euler(0, 0, 0));
        }
    }
	
	// Update is called once per frame
	void Update () {

    }
}
