using UnityEngine;
using System.Collections;

public class StepThroughPortal : MonoBehaviour {

	//set which portal this portal links to
	public GameObject otherPortal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			other.transform.position = otherPortal.transform.position + otherPortal.transform.forward * 2;
		}
	}
	//comment below to orient player when stepping out of portal
	//+adrian dabski I think it is explained in the video how the portals are orientated according to the surface they are thrown on. You could apply almost the exact same code to achieve the correct play rotation. The property you need to modify is called transform.rotation, access it in a script attached to the player and set it to the same roation as the portals when teleporting﻿
	//Make each portal camera mimic the main camera's rotation, and player's position(with an offset of the portal's position relative to world zero minus the main camera's position, I believe), and change the near clipping planes to get larger as the player moves from the portal, and shorter as they move towards it.
}
