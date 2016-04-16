using UnityEngine;
using System.Collections;

public class PlayerPlaneAligner : MonoBehaviour {

    Vector3 mouse_pos;
    Vector3 object_pos;
    float angle;


    public GameObject PlayerSphere;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));

        //transform.rotation = new Quaternion();
        /*
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        transform.Rotate(0, h - v, 0);
        */
    }
}
