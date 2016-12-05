using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	//holds the player
	GameObject Player;
	PlayerScript playerScript;

	//enemy walk speed
	public float enemyWalkSpeed = 5.0f;

	//distance the enemy can look
	public float maxSightDistance = 100.0f;

	//main menu script
	private GameObject mainMenu;
	private MainMenuStart mainMenuScript;

	// Use this for initialization
	void Start () {
		//grab player
		Player = GameObject.Find("Player");
		playerScript = Player.GetComponent<PlayerScript>();

		//grab main menu script
		mainMenu = GameObject.Find ("MainMenu");
		mainMenuScript = mainMenu.GetComponent<MainMenuStart> ();
	}

	// used to keep track of whether the enemy has seen the player since the last movement call
	bool foundPlayer = false;
	// Update is called once per frame
	void Update () {

		//find player
		Vector3 playerLocation = SearchForPlayer ();

		//print (playerLocation.ToString());

		if (playerLocation == Vector3.zero) {	
			//RandomEnemyMovement ();
			foundPlayer = false;
		} else { 
			MoveToLookAtLocation (playerLocation);
			foundPlayer = true;
		}
			

		//SeekPlayerAtLocation (location);
	}

	float lerpMoving=0.0f;
	void MoveToLookAtLocation(Vector3 location){
		//rotate to look at the player
		transform.LookAt(location);

		//movement
		lerpMoving = 0;
		lerpMoving += Time.deltaTime; 
		transform.position = Vector3.MoveTowards(transform.position, location, enemyWalkSpeed * lerpMoving);
	}


	float rx = 0;
	float ry = 0;
	float rz = 0;

	Vector3 lastDirection;

	int leftRightEnemyDecision = -1; //-1 for left, 1 for right (refers to the direction that the enenmy will randomly move towards)
	int currentDirectionCount = 0;
	int maxDirectionCount = 60;

	void RandomEnemyMovement(){
		//found the player and then lost them - choose a new random direction
		if (foundPlayer == true || rx == 0 || ry == 0 || rz == 0){
			rx = transform.position.x;
			ry = transform.position.y; 
			rz = transform.position.z;
			lastDirection = new Vector3 (rx, ry, rz);
		}

		//flip directions of random movement
		if (currentDirectionCount > maxDirectionCount) {
			leftRightEnemyDecision = leftRightEnemyDecision * -1;
			currentDirectionCount = 0;
			maxDirectionCount = Random.Range(40,100);
		}
			
		//still have not found player - increment the past direction we were going
		rx = rx + leftRightEnemyDecision * Random.Range(10, 40);
		ry = this.transform.position.y; 
		rz = rz + Random.Range(0, 1);

		currentDirectionCount += 1;
	

		lastDirection = new Vector3(rx, ry, rz) ;
		MoveToLookAtLocation (lastDirection);
	}

	Vector3 SearchForPlayer(){
		// Checks what is in the zombie's line of sight using a raycaster
		// Uses the player's location to determine if anything is in the way of the player and enemy
		// Return Value: location of player if in line of sight and in front of the enemy, none if not


		//transform.position is the position of the object this script is assigned to
		Vector3 ray_direction = playerScript.player_position - transform.position;

		//debug to see front direction of enemy
		Debug.DrawLine(transform.position, transform.position + ray_direction * maxSightDistance , Color.red);

		//holds information about the ray
		RaycastHit hit;
		//max distance the ray will travel
		maxSightDistance = 1000f;

		if (Physics.Raycast (transform.position, ray_direction, out hit, maxSightDistance)) {

			//print (hit.collider);
			//successfull raycast will put information into hit
			if (hit.transform == Player.transform) {

				//enemy can see the player
				//if (hit.transform.position.z > -0.2f) {
					//the player is in front of the enemy

					return hit.point;
				//}
			}
		}
		//enemy cannot see player
		return Vector3.zero;

	}


	void updatePlayerStats (){
		//set enemy height
		if (mainMenuScript.difficultySetting == 0) {
			enemyWalkSpeed = 4f;
		} else if (mainMenuScript.difficultySetting == 1) {
			enemyWalkSpeed = 5f;
		} else {
			enemyWalkSpeed = 5f;
		}	
	}

}
