using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

	public static GM _instance = null;

	public int lives = 3;
	public int bricks = 25;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;


	private GameObject clonePaddle;

	// Use this for initialization
	void Awake () {
		if (_instance == null) {
			_instance = this;
		} else if (_instance != this) {
			Destroy (gameObject);
		}

		Setup ();
	}

	public void Setup() {
		SetupPaddle ();
		Instantiate (bricksPrefab, transform.position, Quaternion.identity);
	}

	public void CheckGameOver() {
		if (bricks == 0) {
			youWon.SetActive (true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}

		if (lives < 1) {
			gameOver.SetActive (true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}

	}

	private void Reset(){
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void LoseLife(){
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate (deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy (clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver ();
	}

	private void SetupPaddle(){
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
	}

	public void DestroyBrick(){
		bricks--;
		CheckGameOver ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
