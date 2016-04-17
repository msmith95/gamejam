using UnityEngine;
using System.Collections;

public class cheat : MonoBehaviour {


	public BarController h1, h2;
	int h_1, h_2;

	// Use this for initialization
	void Start () {
		h_1 = 100;
		h_2 = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("v")) {
			h_1 -= 10;
			h1.setTopBar (h_1);
		}
		if (Input.GetKeyDown ("b")) {
			h_2 -= 10;
			h2.setTopBar (h_2);
		}
	}
}
