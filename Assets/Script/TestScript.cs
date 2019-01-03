using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    public float lastSpawnPlatformYPosition = 0;
    public static float time = 1f;

    // Use this for initialization
    void Start () {
        Debug.Log("aaa");
        float posX = Random.Range(-2.4f, 2.4f);
        Instantiate(Resources.Load("Bar"), new Vector3(posX, lastSpawnPlatformYPosition + 3, 0), Quaternion.Euler(0, 0, 0));
        lastSpawnPlatformYPosition += 3;
        time += 0.01f;
        Time.timeScale = time;
    }
	
	// Update is called once per frame
	void Update () {

    }
}
