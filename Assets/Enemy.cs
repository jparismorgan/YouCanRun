using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	//holds the player that we GetComponent() of in Start()
	Player player_class;
	public float walk_speed;
	//how far the enemy can look for the player
	public float max_sight_distance;

	// Use this for initialization
	void Start () {
		Player player_class = GetComponent<Player> (); 
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 location = GetLineOfSight ();
		SeekPlayerAtLocation (location);
	}

	void SeekPlayerAtLocation(Vector3 location){
		////////////////////////////////
		//Input: Location
		//Function: Move the object to the location, or walk around randomly of null location passed
		//
		////////////////////////////////
		return;
	}

	Vector3 GetLineOfSight(){
		////////////////////////////////
		//Checks what is in the zombies line of sight using a raycaster
		//Uses the players location to determine if anything is in the way of the player and enemy
		//Return Value: location of player if in line of sight, none if not
		////////////////////////////////

		//player_class.player_position is the player positon, as set in Player.cs
		//transform.position is the position of the object this script is assigned to
		Vector3 ray_direction = player_class.player_position - transform.position;
		//hols information about the ray
		RaycastHit hit;
		//max distance the ray will travel
		max_sight_distance = 1000f;

		if (Physics.Raycast (transform.position, ray_direction, out hit, max_sight_distance)) {
			if (hit.transform == player_class) {
				// enemy can see the player!
				return hit.point;
			} else {
				//enemy cannot see player
				return Vector3.zero;
			}
		} 
		//enemy cannot see player
		return Vector3.zero;

	}

}
