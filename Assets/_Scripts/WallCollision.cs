﻿using UnityEngine;
using System.Collections;

public class WallCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("balloon") || other.gameObject.CompareTag("squirt")) {
			Destroy (other.gameObject);
            print("I'm triggered");
		}
	}
}
