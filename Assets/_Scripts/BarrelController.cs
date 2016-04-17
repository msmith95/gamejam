using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class BarrelController : Photon.MonoBehaviour {

    String tag;

    Vector3 mouse_pos;
    Vector3 object_pos;
	Vector3 ch_object_pos;
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

    int maxBalloonSupply, maxSquirtSupply;


    public Text balloonSupplyText;
    public Text squirtSupplyText;
    public Text squirtDurationText;

	PhotonView barrel;


    // Use this for initialization
    void Start () {
        tag = transform.parent.transform.parent.tag;

        squirting = false;
        squirtCounter = 0;

        maxBalloonSupply = balloonSupply;
        maxSquirtSupply = squirtSupply;
		balloonSupplyText = GameObject.FindGameObjectWithTag ("ballonSupply").GetComponent<Text>() as Text;
		squirtSupplyText = GameObject.FindGameObjectWithTag ("squirtSupply").GetComponent<Text>() as Text;
		squirtDurationText = GameObject.FindGameObjectWithTag ("squirtDuration").GetComponent<Text>() as Text;

		barrel = photonView;
    }
	
	// Update is called once per frame
	void Update () {

        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;

        if (Input.GetMouseButtonDown(0) && Time.time > nextFire && squirtSupply > 0)
        {
            squirting = true;
            nextSquirt = 0;
        }
        else if (Input.GetMouseButtonDown(1) && Time.time > nextFire && balloonSupply > 0)
        {
           /* GameObject balloon = PhotonNetwork.Instantiate("Balloon", transform.position + new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(new Vector3(0, -angle, 0)), 0) as GameObject;
            if (tag == "greenTeam") balloon.GetComponent<fire>().setTeam(0);
            if (tag == "blueTeam") balloon.GetComponent<fire>().setTeam(1);
            fire f = balloon.GetComponent<fire> () as fire;
			f.enabled = true;*/

			ch_object_pos = Camera.main.WorldToScreenPoint (transform.GetChild (1).transform.position);
			barrel.RPC ("createProj", PhotonTargets.AllViaServer, "Balloon", transform.position + new Vector3 (0f, 0f, 0f), angle,Input.mousePosition, ch_object_pos);
			GameObject balloon = GameObject.Instantiate(balloonPrefab, transform.position + new Vector3 (0f, 0f, 0f), Quaternion.Euler (new Vector3 (0, -angle, 0))) as GameObject;
			if (tag == "greenTeam") balloon.GetComponent<fire>().setTeam(0);
			if (tag == "blueTeam") balloon.GetComponent<fire>().setTeam(1);
			fire f = balloon.GetComponent<fire> () as fire;
			f.enabled = true;
			f.setML (Input.mousePosition);
            nextFire = Time.time + squirtFireRate;
            balloonSupply -= 1;
        }

        if (squirting)
        {
            if (Time.time > nextSquirt)
            {
                if (squirtSupply <= 0)
                {
                    squirting = false;
                }
                else if (squirtCounter <= squirtDuration || Input.GetMouseButton(0))
                {
                    squirtCounter += 1;
                    /*GameObject squirt = PhotonNetwork.Instantiate("Squirt", transform.position + new Vector3(0.5f, 0.0f, 0f), Quaternion.Euler(new Vector3(0, -angle, 0)), 0) as GameObject;

                    fire f = squirt.GetComponent<fire> () as fire;
					f.enabled = true;

                    if (tag == "greenTeam") squirt.GetComponent<fire>().setTeam(0);
                    if (tag == "blueTeam") squirt.GetComponent<fire>().setTeam(1);
                    print(squirt.GetComponent<fire>().getTeam());*/
					ch_object_pos = Camera.main.WorldToScreenPoint (transform.GetComponentInChildren<Transform>().position);
					barrel.RPC ("createProj", PhotonTargets.AllViaServer, "Squirt", transform.position + new Vector3 (0.5f, 0f, 0f), angle,Input.mousePosition, ch_object_pos);
					GameObject squirt = GameObject.Instantiate(squirtPrefab, transform.position + new Vector3 (0.5f, 0f, 0f), Quaternion.Euler (new Vector3 (0, -angle, 0))) as GameObject;
					fire f = squirt.GetComponent<fire> () as fire;
					f.enabled = true;
					f.setML (Input.mousePosition);

					if (tag == "greenTeam") squirt.GetComponent<fire>().setTeam(0);
					if (tag == "blueTeam") squirt.GetComponent<fire>().setTeam(1);

                    squirtSupply -= 1;

                    nextSquirt = Time.time + squirtDelay;

                }
                else if (squirtCounter >= squirtDuration || Input.GetMouseButtonUp(0))
                {
                    squirting = false;
                    squirtCounter = 0;
                }
            }

        }

        balloonSupplyText.text = "Balloons - " + balloonSupply.ToString();
        squirtSupplyText.text = "Squirts - " + squirtSupply.ToString();
        squirtDurationText.text = "Squirt Duration - " + squirtDuration.ToString();
    }

    public void refillSupplies(int squirtRate, int balloonRate)
    {
        if(squirtSupply < maxSquirtSupply) squirtSupply += squirtRate;
        if(balloonSupply < maxSquirtSupply) balloonSupply += balloonRate;

        if (squirtSupply > maxSquirtSupply) squirtSupply = maxSquirtSupply;
        if (balloonSupply > maxBalloonSupply) balloonSupply = maxBalloonSupply;
    }

	[PunRPC]
	public void createProj (String prefab, Vector3 position, float rot,Vector3 mouse, Vector3 obj){
		if (!photonView.isMine){
			GameObject squirt;
			if (prefab == "Squirt") {
				squirt = GameObject.Instantiate(squirtPrefab, position, Quaternion.Euler (new Vector3 (0, -rot, 0))) as GameObject;
			} else {
				squirt = GameObject.Instantiate(balloonPrefab, position, Quaternion.Euler (new Vector3 (0, -rot, 0))) as GameObject;
			}

			fire f = squirt.GetComponent<fire> () as fire;
			f.enabled = true;
			f.setML (mouse);
			if (tag == "greenTeam") f.setTeam(0);
			if (tag == "blueTeam") f.setTeam(1);
		}
	}
}


