using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float hmove = Input.GetAxis("Horizontal");
        float vmove = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hmove, 0f, vmove);

        rb.velocity = movement * 20;
    }
}
