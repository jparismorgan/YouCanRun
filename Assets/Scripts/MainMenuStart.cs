using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuStart : MonoBehaviour {

	public Text startMess;
	public Text countDown;
	public Text pauSed;

	public bool titleScreen;
	public bool countdownScreen;
	public bool gameplayScreen;
	public bool spawned;
	public bool paused;

	public int secondsLeft;
	public int timePressed;

	// Use this for initialization
	void Start () {
		// Get Text Components for enabling/ disabling
		Transform StartMess = transform.Find ("StartMess");
		startMess = StartMess.GetComponent<Text> ();
		Transform CountDown = transform.Find("CountDown");
		countDown = CountDown.GetComponent<Text> (); 
		Transform Paused = transform.Find("Paused");
		pauSed = Paused.GetComponent<Text> (); 

		// Initialize flow variables
		titleScreen = true;
		countdownScreen = false;
		gameplayScreen = false;

		spawned = false;
		paused = false;
		startMess.enabled = true;
		countDown.enabled = false; 
		pauSed.enabled = false;
		secondsLeft = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (titleScreen) {
			startMess.enabled = true;
			countDown.enabled = false;
			pauSed.enabled = false;

			paused = false;
		}
			
		if (countdownScreen) { 
			startMess.enabled = false;
			countDown.enabled = true;
			pauSed.enabled = false;

			secondsLeft = 10 - ((int)(Time.time) - timePressed);
			countDown.text = secondsLeft.ToString ("00");

			if (secondsLeft == 0 && !spawned) {
				SpawnEnemies (); 
			}
		}

		if (gameplayScreen && !spawned) { 
			SpawnEnemies ();
		}

		if (Input.GetKeyDown ("p") && titleScreen) {
			titleScreen = false;
			countdownScreen = true;
			gameplayScreen = false;
			timePressed = (int) Time.time;
		}

		if (Input.GetKeyDown ("p") && gameplayScreen) {
			paused = !paused;
		}

		if (paused) {
			pauSed.enabled = true;
			Time.timeScale = 0;
		}

		if (!paused) {
			pauSed.enabled = false;
			Time.timeScale = 1;
		}

		if (Input.GetKeyDown ("escape") && titleScreen) { 
			Application.Quit ();
		}

		if ((Input.GetKeyDown ("escape") && gameplayScreen) ||
			(Input.GetKeyDown ("escape") && gameplayScreen && paused)) {
			ClearGame ();
		}
	}

	void SpawnEnemies () {
		// Spawn Enemies
		spawned = true;

		titleScreen = false;
		countdownScreen = false;
		gameplayScreen = true;

		startMess.enabled = false;
		countDown.enabled = false;
		pauSed.enabled = false;
	}

	void ClearGame() {
		// Clear enemies
		spawned = false;

		titleScreen = true;
		countdownScreen = false;
		gameplayScreen = false;
	}
}
