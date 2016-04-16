using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float jumpSpeed;

	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;
	public GameObject punchPrefab;

	public float fireRate;
	private float nextFire;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void Update(){
		
	}


	void FixedUpdate(){

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.velocity = movement * 10;
		//rb.AddForce (movement * speed);

		if (Input.GetKeyDown ("space") && Time.time > nextFire) {
			GameObject punch = Instantiate(punchPrefab, transform.position + new Vector3 (0.0f, 0.0f, 0.5f), new Quaternion(0f, transform.rotation.y, 0f, 0f)) as GameObject;
				punch.tag = "bullet";
			    nextFire = Time.time + fireRate;
				//punch.GetComponent<Rigidbody>().AddForce(transform.forward * 50000);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 12)
		{
			winText.text = "You Win!";
		}
	}
}
