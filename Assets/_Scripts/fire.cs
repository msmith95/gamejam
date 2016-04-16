﻿using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {
	Rigidbody rb;

    public int projectileSpeed;
	// Use this for initialization
	float xVel, zVel;

    Vector3 mouse_pos;
    Vector3 object_pos;
    float angle;

    void Start () {
		rb = GetComponent<Rigidbody> ();

        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;


        xVel = mouse_pos.x;
        zVel = mouse_pos.y;

		if (Mathf.Abs (xVel) < .8f && xVel != 0f) {
			if(xVel < 0f) xVel = -.8f;
			else xVel = .8f;
		}
		if (Mathf.Abs (zVel) < .8f  && zVel != 0f) {
			if(zVel < 0f) zVel = -.8f;
			else zVel = .8f;
		}
		if (xVel == 0f && zVel == 0f) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = Vector3.Normalize(new Vector3(xVel, 0f, zVel));
		rb.velocity = movement * projectileSpeed;
	}
}