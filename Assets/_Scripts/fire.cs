using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {
	Rigidbody rb;
	// Use this for initialization
	float xVel, zVel;

	void Start () {
		rb = GetComponent<Rigidbody> ();

		xVel = Input.GetAxis ("Horizontal");
		zVel = Input.GetAxis ("Vertical");

		print (xVel);
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
		Vector3 movement = new Vector3(xVel, 0f, zVel);
		rb.velocity = movement * 10;
	}
}
