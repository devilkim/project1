using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject ball;
	float posY = 0;
	void Start() {
		restartPosition ();
	}
	public void restartPosition() {
		posY = 0.65f;
		transform.position = new Vector3 (0, posY, -10);
	}
	void Update () {
		if (posY < ball.transform.position.y) {
			posY = ball.transform.position.y;
			transform.position = new Vector3 (0, Mathf.Lerp (transform.position.y, posY, 0.5f), -10);
		}
	}
}
