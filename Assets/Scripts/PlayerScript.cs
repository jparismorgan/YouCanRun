using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerScript : MonoBehaviour {
	public int health;
	public Vector3 player_position;
	public AudioSource Scream;
	public AudioClip clip;

	private GameObject mainMenu;
	private MainMenuStart mainMenuScript;
	private CharacterController controller;
	private FirstPersonController fpc; 

	// Use this for initialization
	void Start () {
		//grab main menu script
		mainMenu = GameObject.Find ("MainMenu");
		mainMenuScript = mainMenu.GetComponent<MainMenuStart> ();
		Scream = GameObject.Find ("Scream").GetComponent<AudioSource> ();
		clip = Scream.GetComponent<AudioClip> ();

		//grab character controller
		controller = this.GetComponent<CharacterController>();
		fpc = GameObject.FindObjectOfType<FirstPersonController>();
	}
	
	// Update is called once per frame
	void Update () {
		//set player position
		player_position = transform.position;

		//update player stats
		updatePlayerStats ();
	}


	void updatePlayerStats (){
		//set player height
		controller.height = mainMenuScript.playerHeight;

		//set player speed
		fpc.m_WalkSpeed = mainMenuScript.playerSpeed;
		fpc.m_RunSpeed = mainMenuScript.playerSpeed + 10;
	}


	void OnTriggerEnter(Collider other) {
		print (other.gameObject.tag);
		if (other.gameObject.tag == "Enemy") {
			print ("Enemy Hit");
			Scream.PlayOneShot (clip, 1);
			mainMenuScript.isDead = true;
		}
	}

//	void OnCollisionEnter(Collision collision) {
//		print (collision.gameObject.tag);
//		if (collision.gameObject.tag == "Enemy") {
//			Scream.PlayOneShot (clip, 1);
//			mainMenuScript.isDead = true;
//		}
//	}
}
