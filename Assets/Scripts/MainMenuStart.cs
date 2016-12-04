using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuStart : MonoBehaviour {

	public Text startMess;
	public Text countDown;
	public Text pauSed;
	public Text pausedReturnMess;
	public Text settingsMess;
	public Text playerHeightLabel;
	public Slider playerHeightSlider;
	public GameObject playerHeightOBJ;
	public Text playerSpeedLabel;
	public Slider playerSpeedSlider;
	public GameObject playerSpeedOBJ;
	public Text difficultyLabel;
	public Dropdown difficulty;
	public GameObject difficultyOBJ;
	public Text settingsReturnMess;
	public Text instructionMess;

	// Set in Settings Menu
	public int playerSpeed; // From 0 to 6;
	public int playerHeight; // From 0 to 6;
	public int difficultySetting; // 0: Easy, 1: Normal, 2: Insane

	public bool titleScreen;
	public bool instructionScreen;
	public bool settingsScreen;
	public bool countdownScreen;
	public bool gameplayScreen;
	public bool spawned;
	public bool paused;

	public int secondsLeft;
	public int timePressed;

	// Use this for initialization
	void Start () {
		playerHeightOBJ = GameObject.Find ("PlayerHeightSlider");
		playerSpeedOBJ = GameObject.Find ("PlayerSpeedSlider"); 
		difficultyOBJ = GameObject.Find ("Difficulty"); 

		startMess.enabled = false;
		countDown.enabled = false;
		pauSed.enabled = false;
		pausedReturnMess.enabled = false;
		settingsMess.enabled = false;
		playerHeightLabel.enabled = false;
		playerHeightSlider.enabled = false;
		playerHeightOBJ.SetActive(false);
		playerSpeedLabel.enabled = false;
		playerSpeedSlider.enabled = false; 
		playerSpeedOBJ.SetActive(false);
		difficultyLabel.enabled = false;
		difficulty.enabled = false;
		difficultyOBJ.SetActive(false);
		settingsReturnMess.enabled = false;
		instructionMess.enabled = false;

		// Initialize flow variables
		titleScreen = true;
		instructionScreen = false;
		settingsScreen = false;
		countdownScreen = false;
		gameplayScreen = false;
		spawned = false;
		paused = false;
		secondsLeft = 10;

		// Initial Settings Menu Values
		playerSpeed = 3;
		playerHeight = 3;
		difficultySetting = 1;
	}
	
	// Update is called once per frame
	void Update () {
		// TITLE SCREEN CASES
		if (titleScreen) {
			startMess.enabled = true;
			countDown.enabled = false;
			pauSed.enabled = false;
			pausedReturnMess.enabled = false;
			settingsMess.enabled = false;
			playerHeightLabel.enabled = false;
			playerHeightSlider.enabled = false;
			playerHeightOBJ.SetActive(false);
			playerSpeedLabel.enabled = false;
			playerSpeedSlider.enabled = false; 
			playerSpeedOBJ.SetActive(false);
			difficultyLabel.enabled = false;
			difficulty.enabled = false;
			difficultyOBJ.SetActive(false);
			settingsReturnMess.enabled = false;
			instructionMess.enabled = false;

			paused = false;	
		}

		if (titleScreen && Input.GetKeyDown ("i")) {
			titleScreen = false;
			instructionScreen = true;
			settingsScreen = false;
			countdownScreen = false;
			gameplayScreen = false;

		}

		if (titleScreen && Input.GetKeyDown ("e")) {
			titleScreen = false;
			instructionScreen = false;
			settingsScreen = true;
			countdownScreen = false;
			gameplayScreen = false;
		}

		if (titleScreen && Input.GetKeyDown ("escape")) { 
			Application.Quit ();
		}

		if (titleScreen && Input.GetKeyDown ("p")) {
			titleScreen = false;
			instructionScreen = false;
			settingsScreen = false;
			countdownScreen = true;
			gameplayScreen = false;
			timePressed = (int) Time.time;
		}
			

		// INSTRUCTION SCREEN CASES
		if (instructionScreen) {
			startMess.enabled = false;
			countDown.enabled = false;
			pauSed.enabled = false;
			pausedReturnMess.enabled = false;
			settingsMess.enabled = false;
			playerHeightLabel.enabled = false;
			playerHeightSlider.enabled = false;
			playerHeightOBJ.SetActive(false);
			playerSpeedLabel.enabled = false;
			playerSpeedSlider.enabled = false;
			playerSpeedOBJ.SetActive(false);
			difficultyLabel.enabled = false;
			difficulty.enabled = false;
			difficultyOBJ.SetActive(false);
			settingsReturnMess.enabled = false;
			instructionMess.enabled = true;
		}

		if (instructionScreen && Input.GetKeyDown ("b")) {
			titleScreen = true;
			instructionScreen = false;
			settingsScreen = false;
			countdownScreen = false;
			gameplayScreen = false;
		}


		// SETTINGS SCREEN CASES
		if (settingsScreen) {
			startMess.enabled = false;
			countDown.enabled = false;
			pauSed.enabled = false;
			pausedReturnMess.enabled = false;
			settingsMess.enabled = true;
			playerHeightLabel.enabled = true;
			playerHeightSlider.enabled = true;
			playerHeightOBJ.SetActive(true);
			playerSpeedLabel.enabled = true;
			playerSpeedSlider.enabled = true;
			playerSpeedOBJ.SetActive(true);
			difficultyLabel.enabled = true;
			difficulty.enabled = true;
			difficultyOBJ.SetActive(true);
			settingsReturnMess.enabled = true;
			instructionMess.enabled = false;

			playerHeight = (int) playerHeightSlider.value;
			playerSpeed = (int) playerSpeedSlider.value;
			difficultySetting = (int) difficulty.value;
		}

		if (settingsScreen && Input.GetKeyDown ("b")) {
			titleScreen = true;
			instructionScreen = false;
			settingsScreen = false;
			countdownScreen = false;
			gameplayScreen = false;
		}
			
				// Height Setting
				if(settingsScreen && Input.GetKeyDown ("q")) {
					playerHeightSlider.value--;
				}

				if (settingsScreen && Input.GetKeyDown ("r")) {
					playerHeightSlider.value++;
				}

				// Difficulty Setting
				if(settingsScreen && Input.GetKeyDown ("f")) {
					difficulty.value = 0;
				}

				if(settingsScreen && Input.GetKeyDown ("n")) {
					difficulty.value = 1;
				}

				if(settingsScreen && Input.GetKeyDown ("c")) {
					difficulty.value = 2;
				}

				// Speed Setting
				if(settingsScreen && Input.GetKeyDown ("j")) {
					playerSpeedSlider.value--;
				}

				if (settingsScreen && Input.GetKeyDown ("l")) {
					playerSpeedSlider.value++;
				}


		// COUNTDOWN SCREEN
		if (countdownScreen) { 
			startMess.enabled = false;
			countDown.enabled = true;
			pauSed.enabled = false;
			pausedReturnMess.enabled = false;
			settingsMess.enabled = false;
			playerHeightLabel.enabled = false;
			playerHeightSlider.enabled = false;
			playerHeightOBJ.SetActive(false);
			playerSpeedLabel.enabled = false;
			playerSpeedSlider.enabled = false;
			playerSpeedOBJ.SetActive(false);
			difficultyLabel.enabled = false;
			difficulty.enabled = false;
			difficultyOBJ.SetActive(false);
			settingsReturnMess.enabled = false;
			instructionMess.enabled = false;

			secondsLeft = 10 - ((int)(Time.time) - timePressed);
			countDown.text = secondsLeft.ToString ("00");

			if (secondsLeft == 0 && !spawned) {
				SpawnEnemies (); 
			}
		}


		// GAMEPLAY CASES
		if (gameplayScreen) {
			startMess.enabled = false;
			countDown.enabled = false;
			pauSed.enabled = false;
			pausedReturnMess.enabled = false;
			settingsMess.enabled = false;
			playerHeightLabel.enabled = false;
			playerHeightSlider.enabled = false;
			playerHeightOBJ.SetActive(false);
			playerSpeedLabel.enabled = false;
			playerSpeedSlider.enabled = false;
			playerSpeedOBJ.SetActive(false);
			difficultyLabel.enabled = false;
			difficulty.enabled = false;
			difficultyOBJ.SetActive(false);
			settingsReturnMess.enabled = false;
			instructionMess.enabled = false;
		}

		if (gameplayScreen && Input.GetKeyDown ("p")) {
			paused = !paused;
		}

		if (gameplayScreen && Input.GetKeyDown ("escape")) {
			ClearGame ();
		}

		// PAUSED SCREEN CASES
		if (paused) {	
			Time.timeScale = 0;
			startMess.enabled = false;
			countDown.enabled = false;
			pauSed.enabled = true;
			pausedReturnMess.enabled = true;
			settingsMess.enabled = false;
			playerHeightLabel.enabled = false;
			playerHeightSlider.enabled = false;
			playerHeightOBJ.SetActive(false);
			playerSpeedLabel.enabled = false;
			playerSpeedSlider.enabled = false;
			playerSpeedOBJ.SetActive(false);
			difficultyLabel.enabled = false;
			difficulty.enabled = false;
			difficultyOBJ.SetActive(false);
			settingsReturnMess.enabled = false;
			instructionMess.enabled = false;
		}

		if ((gameplayScreen && !paused) || (titleScreen && !paused)) {
			Time.timeScale = 1;
		}

		if (paused && Input.GetKeyDown ("escape")) {
			ClearGame ();
		}
	}

	void SpawnEnemies () {
		// Spawn Enemies
		spawned = true;

		titleScreen = false;
		instructionScreen = false;
		settingsScreen = false;
		countdownScreen = false;
		gameplayScreen = true;
	}

	void ClearGame() {
		// Clear enemies
		spawned = false;
		paused = false;

		titleScreen = true;
		instructionScreen = false;
		settingsScreen = false;
		countdownScreen = false;
		gameplayScreen = false;
	}
}
