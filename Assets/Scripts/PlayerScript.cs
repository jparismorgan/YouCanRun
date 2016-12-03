using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public int health;
	public Vector3 player_position;

	// Use this for initialization
	void Start () {
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		//set player position so that EnemyScript.cs can use it
		player_position = transform.position;


	}
}
