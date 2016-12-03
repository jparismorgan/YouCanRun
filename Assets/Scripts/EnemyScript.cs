using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	//holds the player that we GetComponent() of in Start()
	GameObject Player;
	PlayerScript playerScript;
	public float walkSpeed = 5.0f;
	//how far the enemy can look for the player
	public float maxSightDistance;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find("Player");
		playerScript = Player.GetComponent<PlayerScript>();
	}


	float lerpMoving=0.0f;
	// Update is called once per frame
	void Update () {

		//find player
		Vector3 playerLocation = SearchForPlayer ();
		print (playerLocation);

		if (playerLocation == Vector3.zero) {	
			RandomEnemyMovement ();
		} else { 
			SeekPlayerAtLocation (playerLocation);
		}
			
		//debug to see front direction of enemy
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		Debug.DrawLine(transform.position, transform.position+fwd*30.0f, Color.red);

		//SeekPlayerAtLocation (location);
	}

	void SeekPlayerAtLocation(Vector3 location){
		////////////////////////////////
		//Input: Location
		//Function: Move the object to the location, or walk around randomly of null location passed
		//
		////////////////////////////////
		float elapsedTime=0.0f;

			if (playerLocation == Vector3.zero) {
				//no movement}
			} else {
				lerpMoving = 0;
				lerpMoving += Time.deltaTime; 
				transform.position = Vector3.MoveTowards(transform.position, playerLocation, walkSpeed * lerpMoving);
				//
				//			elapsedTime += Time.deltaTime;
				//			float percentComplete = elapsedTime / 3.0f; //go from 0.0 to 1.0
				//			float clampedValue=Mathf.Clamp (percentComplete, 0.0f, 1.0f);
				//			transform.position = Vector3.Lerp (transform.position, playerLocation, clampedValue);
			}


//		elapsedTime += Time.deltaTime;
//		float percentComplete = elapsedTime / 3.0f; //go from 0.0 to 1.0
//		float clampedValue=Mathf.Clamp (percentComplete, 0.0f, 1.0f);
//		transform.position = Vector3.Lerp (startPos, endPos, clampedValue);

		return;
	}

	Vector3 SearchForPlayer(){
		////////////////////////////////
		//Checks what is in the zombie's line of sight using a raycaster
		//Uses the player's location to determine if anything is in the way of the player and enemy
		//Return Value: location of player if in line of sight and in front of the enemy, none if not
		////////////////////////////////

		//player_class.player_position is the player positon, as set in PlayerScript.cs
		//transform.position is the position of the object this script is assigned to
		Vector3 ray_direction = playerScript.player_position - transform.position;
		//holds information about the ray
		RaycastHit hit;
		//max distance the ray will travel
		maxSightDistance = 1000f;

		if (Physics.Raycast (transform.position, ray_direction, out hit, maxSightDistance)) {
		//successull raycast will put information into hit
			if (hit.transform == Player.transform) {
				//enemy can see the player
				if (hit.transform.position.z > -0.2f) {
					//the player is in front of the enemy
					return hit.point;
				}
			}
		}
		//enemy cannot see player
		return Vector3.zero;

	}

}
