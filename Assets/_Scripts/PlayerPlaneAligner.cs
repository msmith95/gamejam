using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerPlaneAligner : MonoBehaviour {

    Vector3 mouse_pos;
    Vector3 object_pos;
    float angle;

    public GameObject balloonPrefab;
    public GameObject squirtPrefab;
    public float balloonFireRate;
    public float squirtFireRate;
    private float nextFire;
    public int balloonSupply;
    public int squirtSupply;
    public int squirtDuration;
    bool squirting;
    int squirtCounter;
    public float squirtDelay;
    float nextSquirt;


    public Text balloonSupplyText;
    public Text squirtSupplyText;
    public Text squirtDurationText;


    // Use this for initialization
    void Start () {
        squirting = false;
        squirtCounter = 0;
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

        if (Input.GetMouseButtonDown(0) && Time.time > nextFire && squirtSupply > 0)
        {
            squirting = true;
            nextSquirt = 0;
        }
        else if (Input.GetMouseButtonDown(1) && Time.time > nextFire && balloonSupply > 0)
        {
            GameObject balloon = Instantiate(balloonPrefab, transform.position + new Vector3(0.0f, 0.0f, 0.5f), Quaternion.Euler(new Vector3(0, -angle, 0))) as GameObject;
            nextFire = Time.time + squirtFireRate;
            balloonSupply -= 1;
        }

        if (squirting)
        {
            if (Time.time > nextSquirt) {
                if(squirtSupply <= 0)
                {
                    squirting = false;
                }
                else if (squirtCounter <= squirtDuration || Input.GetMouseButton(0))
                {
                    squirtCounter += 1;
                    GameObject squirt = Instantiate(squirtPrefab, transform.position + new Vector3(0.0f, 0.0f, 0.5f), Quaternion.Euler(new Vector3(0, -angle, 0))) as GameObject;
                    squirtSupply -= 1;
                
                    nextSquirt = Time.time + squirtDelay;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    squirting = false;
                    squirtCounter = 0;
                }
            }

            
            
            /*
            if (squirtCounter == squirtDuration)
            {
                squirting = false;
                squirtCounter = 0;
                nextFire = Time.time + squirtFireRate;
            }*/
        }

        balloonSupplyText.text = "Balloons - " + balloonSupply.ToString();
        squirtSupplyText.text = "Squirts - " + squirtSupply.ToString();
        squirtDurationText.text = "Squirt Duration - " + squirtDuration.ToString();
    }
}
