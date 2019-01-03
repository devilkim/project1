using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelect : MonoBehaviour {

	public GameObject mainUI;
	public GameObject gameUI;
	public GameObject pauseMenuUI;
	public GameObject gameOverUI;
	public GameObject transitionImage;
	public GameObject startPlatform;
	public GameObject ball;
	public GameObject scoreText;
	ObstacleSpawn obstacleSpawn;
	PlayerMovement playerMovement;

	private bool changeMenu = false;
	private float imageTransparency = 0;
	private bool increaseTransparency = true;
	private float timer = 0;
	private Image transition;
	private AudioSource buttonSound;

	private int chooseMenu = 1;//1 - play, 2-exit
	private Text heightText;
	void Start () {
		obstacleSpawn = GameObject.Find ("Main Camera").GetComponent<ObstacleSpawn> ();
		playerMovement = ball.GetComponent<PlayerMovement> ();
		transition = transitionImage.GetComponent<Image> ();
		heightText = scoreText.GetComponent<Text> ();
		buttonSound = GameObject.Find ("buttonSound").GetComponent<AudioSource> ();
	}
	void Update() {
		if (changeMenu == true) {
			timer += Time.deltaTime;
			if(timer >= 0.01f) {
				timer = 0;
				if (increaseTransparency == true) {
					imageTransparency += 0.05f;
					if (imageTransparency >= 1f) {
						increaseTransparency = false;
						if (chooseMenu == 1) {
							playLogic ();
						} else if (chooseMenu == 2) {
							exitLogic ();
						}
					}
				} else {
					imageTransparency -= 0.05f;
					if (imageTransparency <= 0) {
						increaseTransparency = true;
						changeMenu = false;
					}
				}
				transition.color = new Color (0, 0, 0, imageTransparency);
			}
		}
	}
	public void play() {
		playSound ();
		changeMenu = true;
		chooseMenu = 1;
	}
	public void playLogic() {
		mainUI.SetActive (false);
		gameUI.SetActive (true);
		obstacleSpawn.enabled = true;
		playerMovement.enabled = true;
		ball.SetActive (true);
		startPlatform.SetActive (true);
		Time.timeScale = 1;
	}
	public void pause () {
		playSound ();
		Time.timeScale = 0;
		pauseMenuUI.SetActive (true);
		playerMovement.enabled = false;
	}
	public void resume () {
		playSound ();
		Time.timeScale = ObstacleSpawn.time;
		pauseMenuUI.SetActive (false);
		playerMovement.enabled = true;
	}
	public void playSound () {
		buttonSound.Play ();
	}
	public void restart() {
		ObstacleSpawn.time = 1;
		ball.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		ball.GetComponent<Rigidbody2D> ().angularVelocity = 0;
		ball.GetComponent<Rigidbody2D> ().transform.position = new Vector2 (0, 0.65f);
		ball.GetComponent<BoxCollider2D> ().isTrigger = false;
		GameObject[] platforms = GameObject.FindGameObjectsWithTag ("platform");
		for (int i = 0; i < platforms.Length; i++) {
			Destroy (platforms [i]);
		}

		GameObject.Find ("Main Camera").GetComponent<ObstacleSpawn> ().lastSpawnPlatformYPosition = 0;

		ball.GetComponent<PlayerMovement> ().start = false;
		ball.GetComponent<PlayerMovement> ().restart ();
		ball.GetComponent<PlayerMovement> ().height = 0;
		ball.GetComponent<PlayerMovement> ().enabled = true;
		pauseMenuUI.SetActive (false);
		gameOverUI.SetActive (false);

		heightText.text = "HEIGHT: 0";
		GameObject.Find ("Main Camera").GetComponent<CameraFollow> ().restartPosition ();
		GameObject.Find ("Main Camera").GetComponent<Transform> ().position = new Vector3 (0,0.75f,-10);

	}
	public void exit() {
		playSound ();
		Time.timeScale = 1;
		changeMenu = true;
		chooseMenu = 2;
	}
		
	public void exitLogic() {
		mainUI.SetActive (true);
		gameUI.SetActive (false);
		obstacleSpawn.enabled = false;
		playerMovement.enabled = false;
		ball.SetActive (false);
		startPlatform.SetActive (false);
		Time.timeScale = 1;
		restart ();
	}
}
