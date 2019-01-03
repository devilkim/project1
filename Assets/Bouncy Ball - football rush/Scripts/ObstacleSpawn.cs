using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {

	public GameObject ball;
	public float lastSpawnPlatformYPosition = 0;
	public static float time = 1f;

	void Start() {
		time = 1f;
	}

	void Update () {
		if (ball.transform.position.y > lastSpawnPlatformYPosition - 12) {
			float posX = Random.Range (-2.4f, 2.4f);
			int randomPlatform = Random.Range (1, 4);
			Instantiate (Resources.Load ("platform" + randomPlatform), new Vector3 (posX, lastSpawnPlatformYPosition + 3, 0), Quaternion.Euler(0,0,0));
			lastSpawnPlatformYPosition += 3;
			time += 0.01f;
			Time.timeScale = time;
		}
	}
}
