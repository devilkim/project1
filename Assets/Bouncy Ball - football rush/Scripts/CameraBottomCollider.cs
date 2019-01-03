using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBottomCollider : MonoBehaviour {

	public GameObject gameOverUI;
	private AudioSource gameOverSound;
	void Start () {
		gameOverSound = GameObject.Find ("gameOver").GetComponent<AudioSource> ();
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name.Equals ("ball")) {
			GameObject.Find ("ball").GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			GameObject.Find ("ball").GetComponent<Rigidbody2D> ().angularVelocity = 0;
			GameObject.Find ("ball").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionY;
			gameOverUI.SetActive (true);
			gameOverSound.Play ();

		} else if(col.gameObject.name.Contains("platform")) {
			Destroy (col.gameObject);
		}
	}
}
