using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {
	Rigidbody rb;

    public int projectileSpeed;
	// Use this for initialization
	float xVel, zVel;

    Vector3 mouse_pos;
    Vector3 object_pos;
    float angle;

    int team;
	Vector3 mouseLoc;

	bool firstTime;

    void Start () {
		firstTime = true;

		rb = GetComponent<Rigidbody> ();




	}

	// Update is called once per frame
	void Update () {


		if (firstTime) {

			mouse_pos = mouseLoc;
			mouse_pos.z = 5.23f; //The distance between the camera and object
			object_pos = Camera.main.WorldToScreenPoint(transform.position);
			mouse_pos.x = mouse_pos.x - object_pos.x;
			mouse_pos.y = mouse_pos.y - object_pos.y;

			xVel = mouse_pos.x;
			zVel = mouse_pos.y;

			if (Mathf.Abs (xVel) < .8f && xVel != 0f) {
				if (xVel < 0f)
					xVel = -.8f;
				else
					xVel = .8f;
			}
			if (Mathf.Abs (zVel) < .8f && zVel != 0f) {
				if (zVel < 0f)
					zVel = -.8f;
				else
					zVel = .8f;
			}
			if (xVel == 0f && zVel == 0f) {
				Destroy (gameObject);
			}

			firstTime = false;
		}

		
		Vector3 movement = Vector3.Normalize(new Vector3(xVel, 0f, zVel));
		rb.velocity = movement * projectileSpeed;

	}

    public int getTeam()
    {
        return team;
    }

    public void setTeam(int _team)
    {
        team = _team;
    }

	public void setML (Vector3 ml)
	{
		mouseLoc = ml;
	}
}
