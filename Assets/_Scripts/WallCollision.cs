using UnityEngine;
using System.Collections;

public class WallCollision : MonoBehaviour {

    GameObject splat;

	// Use this for initialization
	void Start () {
        splat = GameObject.FindGameObjectWithTag("splat") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("balloon") || other.gameObject.CompareTag("squirt")) {
			Destroy (other.gameObject);

            splat.GetComponent<AudioSource>().Play();
		}
	}
}
