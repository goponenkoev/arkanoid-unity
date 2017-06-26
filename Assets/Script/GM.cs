using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	public int lives = 3;
	public int bricks = 15;
	public float resetDelay = 1f;
	public Text livesText;
	public Text scoreText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject stady;
	public GameObject ready;
	public GameObject go;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject ball;
	public GameObject deathParticles;
	public static GM instance = null;

	private GameObject clonePaddle;
	private int bricksAll;
	private bool gOver = false;
	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		bricksAll = bricks + 1;
		Setup ();
	}

	void Setup(){
		//clonePaddle = Instantiate (paddle,transform.position, Quaternion.identity);
		//Instantiate (bricksPrefab, transform.position, Quaternion.identity);
		clonePaddle = Instantiate (paddle,transform.position = new Vector3(-0.2f,-4f,-6f), Quaternion.identity);
		Instantiate (bricksPrefab, transform.position = new Vector3(2f,3f,-18.47f), Quaternion.identity);
	}

	IEnumerator RestartGame(){
		yield return new WaitForSeconds(0.25f);
		youWon.SetActive (false);
		gameOver.SetActive (false);
		stady.SetActive (true);
		yield return new WaitForSeconds(0.25f);
		stady.SetActive (false);
		ready.SetActive (true);
		yield return new WaitForSeconds(0.25f);
		ready.SetActive (false);
		go.SetActive (true);
		yield return new WaitForSeconds(0.25f);
		go.SetActive (false);
	}

	IEnumerator RestartGame1(){
		yield return new WaitForSeconds(0.25f);
		//youWon.SetActive (false);
		gameOver.SetActive (false);
		stady.SetActive (true);
		yield return new WaitForSeconds(0.25f);
		stady.SetActive (false);
		ready.SetActive (true);
		yield return new WaitForSeconds(0.25f);
		ready.SetActive (false);
		go.SetActive (true);
		yield return new WaitForSeconds(0.25f);
		go.SetActive (false);
	}
	void CheckGameOver(){
		if ((bricks < 1)&&(gOver == false)){
			youWon.SetActive (true);
			gOver = true;
			Time.timeScale = 0.25f;
			StartCoroutine (RestartGame());
			Invoke ("Reset", resetDelay);
		}

		if ((lives < 1)&&(gOver == false)){
			gameOver.SetActive (true);
			gOver = true;
			Time.timeScale = 0.25f;
			StartCoroutine (RestartGame1());
			Invoke ("Reset", resetDelay);
		}
	}

	void Reset(){
		Time.timeScale = 1f;
		Application.LoadLevel (Application.loadedLevel);
	}

	public void LoseLife(){
		lives--;
		livesText.text = "Lives " + (lives);
		//Destroy (clonePaddle);
		//Destroy (ball);
		//Invoke ("SetupPaddle",resetDelay);
		CheckGameOver ();
	}

	void SetupPaddle(){
		clonePaddle = Instantiate (paddle,transform.position = new Vector3(-0.2f,-4f,-6f), Quaternion.identity);
	}

	public void DestroyBrick(){
		scoreText.text = "Score: " + (bricksAll - bricks);
		bricks--;
		CheckGameOver();
	}
}
