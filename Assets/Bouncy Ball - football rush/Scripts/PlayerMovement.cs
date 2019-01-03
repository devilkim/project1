using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rb;
	private BoxCollider2D bc;
	private AudioSource jumpSound;
	public bool start = false;
	public GameObject scoreTextUI;
	private Text scoreText;
	public int height = 0;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		bc = GetComponent <BoxCollider2D> ();
		scoreText = scoreTextUI.GetComponent<Text> ();
	}
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (start == false) {
				start = true;
				rb.AddForce (new Vector2 (0, 420f));
				bc.isTrigger = true;
				jumpSound = GameObject.Find ("jump").GetComponent<AudioSource> ();
				jumpSound.Play ();
				GameObject.Find ("ball").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				GameObject.Find ("ball").GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
			}
		}
		if (start == true) {
			Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = new Vector2 (Mathf.Lerp (rb.transform.position.x, pos.x, 0.5f), transform.position.y);
		}
		if (height < transform.position.y) {
			height = (int)transform.position.y;
			scoreText.text = "HEIGHT: " + height;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (!col.gameObject.name.Equals ("cameraCollider")) {
			if (rb.velocity.y < 0f) {
				restart ();
				rb.AddForce (new Vector2 (0, 420));
				jumpSound.Play ();
			} 
		}
	}
	public void restart() {
		rb.velocity = Vector2.zero;
	}
		
}
