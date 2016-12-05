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
	public Text deathMess;
	public Text deathTime;

	// Set in Settings Menu
	public int playerSpeed; // From 3 to 20, 6 default
	public int playerHeight; // From 1 to 6, 2 default
	public int difficultySetting; // 0: Easy, 1: Normal, 2: Insane

	public bool titleScreen;
	public bool instructionScreen;
	public bool settingsScreen;
	public bool countdownScreen;
	public bool gameplayScreen;
	public bool spawned;
	public bool paused;
	public bool isDead;

	public int secondsLeft;
	public int timePressed;

	//Terrain info
	public Terrain terrain;
	private int terrainWidth; // terrain size (x)
	private int terrainLength; // terrain size (z)
	private int terrainPosX; // terrain position x
	private int terrainPosZ; // terrain position z

	// Enemy
	public GameObject enemyToSpawn;

	// Use this for initialization
	void Start () {
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
		deathMess.enabled = false;
		deathTime.enabled = false;

		// Initialize flow variables
		titleScreen = true;
		instructionScreen = false;
		settingsScreen = false;
		countdownScreen = false;
		gameplayScreen = false;
		spawned = false;
		paused = false;
		isDead = false;
		secondsLeft = 10;

		// Initial Settings Menu Values
		playerSpeed = 6;
		playerHeight = 2;
		difficultySetting = 1;

		// Get terrain settings
		// terrain size x
		terrainWidth = (int)terrain.terrainData.size.x;
		// terrain size z
		terrainLength = (int)terrain.terrainData.size.z;
		// terrain x position
		terrainPosX = (int)terrain.transform.position.x;
		// terrain z position
		terrainPosZ = (int)terrain.transform.position.z;
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
			deathMess.enabled = false;
			deathTime.enabled = false;

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
			deathMess.enabled = false;
			deathTime.enabled = false;
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
			deathMess.enabled = false;
			deathTime.enabled = false;

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
			deathMess.enabled = false;
			deathTime.enabled = false;

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
			deathMess.enabled = false;
			deathTime.enabled = false;
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
			deathMess.enabled = false;
			deathTime.enabled = false;
		}

		if ((gameplayScreen && !paused) || (titleScreen && !paused)) {
			Time.timeScale = 1;
		}

		if (paused && Input.GetKeyDown ("escape")) {
			ClearGame ();
		}

		// DEATH CASE
		if (isDead) {
			Time.timeScale = 0;
			deathTime.text = (Time.time).ToString();

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
			deathMess.enabled = true;
			deathTime.enabled = true;
		}

		if (isDead && Input.GetKeyDown (KeyCode.Escape)) {
			ClearGame ();
		}
	}



	void SpawnEnemies () {
		// Spawn Enemies

		//settings related to menu screens
		spawned = true;
		titleScreen = false;
		instructionScreen = false;
		settingsScreen = false;
		countdownScreen = false;
		gameplayScreen = true;

		int currentSpawnCount = 0;
		int spawnCount;

		if (difficultySetting == 0) {
			spawnCount = 5;
		} else if (difficultySetting == 1) {
			spawnCount = 10;
		} else {
			spawnCount = 15;
		}	


		while (currentSpawnCount < spawnCount) {
			// generate random x position
			int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
			// generate random z position
			int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
			// get the terrain height at the random position
			float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));
			// create new gameObject on random position
			GameObject newObject = (GameObject)Instantiate(enemyToSpawn, new Vector3(posx, posy, posz), Quaternion.identity);
			currentSpawnCount += 1;
		}
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
