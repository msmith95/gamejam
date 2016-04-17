using UnityEngine;
using System.Collections;
using Photon;
public class Randomizer : Photon.PunBehaviour {

	GameObject monster;
	// Use this for initialization
	void Start () {
		//PhotonNetwork.logLevel = PhotonLogLevel.Full;
		PhotonNetwork.ConnectUsingSettings ("0.1");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	void OnGUI(){
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Can't join random room!");
		PhotonNetwork.CreateRoom(null);
	}
	public override void OnJoinedRoom ()
	{
		if (PhotonNetwork.playerList.Length == 1) {
			monster = PhotonNetwork.Instantiate ("Player", new Vector3 (-57.6f, 4f, 0f), Quaternion.identity, 0);
			monster.tag = "greenTeam";
		} else {
			monster = PhotonNetwork.Instantiate ("Player", new Vector3 (57.6f, 4f, 0f), Quaternion.identity, 0);
			monster.tag = "blueTeam";
		}
		PlayerController controller = monster.GetComponent<PlayerController> ();
		controller.enabled = true;
        PlayerHealthController controller2 = monster.GetComponent<PlayerHealthController>();
        controller2.enabled = true;
        controller.activeScript(); 
	}
}
