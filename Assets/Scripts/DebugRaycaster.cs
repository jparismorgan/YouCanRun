using UnityEngine;
using System.Collections;

public class DebugRaycaster : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float maxSightDistance = 1000f;

		Vector3 temp = new Vector3 (0f, -200f, 60f);
		Vector3 ray_direction = temp - transform.position;

		//debug to see front direction of enemy
		Debug.DrawLine(transform.position, transform.position + ray_direction * maxSightDistance , Color.red);


		//holds information about the ray
		RaycastHit hit;
		//max distance the ray will travel


		Physics.Raycast (transform.position, ray_direction, out hit, maxSightDistance);
		//print (hit.collider);
	}
}
