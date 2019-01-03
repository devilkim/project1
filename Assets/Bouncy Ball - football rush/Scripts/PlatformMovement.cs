using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

	private bool left = true;
	private float posX = 0;
	public float speed = 0.05f;

	void FixedUpdate () {
		if (left == true) {
			posX -= speed;
			if (posX < -2.4f) {
				left = false;
			}
		} else {
			posX += speed;
			if (posX > 2.4f) {
				left = true;
			}
		}
		transform.position = new Vector2 (posX, transform.position.y);
	}
}
