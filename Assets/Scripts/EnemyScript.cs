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
			RandomEnemyMovement ();
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

	int goTowards = 0; //0 for left, 1 for right, 2 for up (refers to the direction that the enenmy will randomly move towards)

	int currentDirectionCount = 0;
	int maxDirectionCount = 10;

	void RandomEnemyMovement(){
		//found the player and then lost them - choose a new random direction
		if (foundPlayer == true || currentDirectionCount > maxDirectionCount){
			goTowards = goTowards + 1;
			goTowards = (goTowards > 2) ? 0 : goTowards;  //goTowards = 0 if goTowards > 2 else goTowards = 0
			lastDirection = Vector3.zero;
			maxDirectionCount = Random.Range(40,100);
			currentDirectionCount = 0;
			rx = 0;
			ry = 0;
			rz = 0;

		//	print (goTowards);

//			rx = transform.position.x;
//			ry = transform.position.y; 
//			rz = transform.position.z;
//			lastDirection = new Vector3 (rx, ry, rz);
		}

		if (goTowards == 0) {
			//left { decrement x, increment z}
			rx = rx + Random.Range(-15, -2);
			ry = this.transform.position.y; 
			rz = rz + Random.Range(0, 3);

		} else if (goTowards == 1) {
			//right { increment x, increment z}
			rx = rx + Random.Range(2, 15);
			ry = this.transform.position.y; 
			rz = rz + Random.Range(0, 3);
		
		} else {
			//up { increment y }
			rx = this.transform.position.x;
			ry = ry + Random.Range(5, 10);
			rz = this.transform.position.z;
		}
			
		currentDirectionCount += 1;
	
		//print (currentDirectionCount);

		lastDirection = new Vector3(rx, ry, rz);

		print (lastDirection);

		MoveToLookAtLocation (lastDirection);
	}

	Vector3 SearchForPlayer(){
		// Checks what is in the zombie's line of sight using a raycaster
		// Uses the player's location to determine if anything is in the way of the player and enemy
		// Return Value: location of player if in line of sight and in front of the enemy, none if not


		//transform.position is the position of the object this script is assigned to
		Vector3 ray_direction = playerScript.player_position - transform.position;

		//debug to see front direction of enemy
		//Debug.DrawLine(transform.position, transform.position + ray_direction * maxSightDistance , Color.red);

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
			enemyWalkSpeed = 7f;
		}	
	}

}
