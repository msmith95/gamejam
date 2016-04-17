using UnityEngine;
using System.Collections;

public class NetworkSpritePlane : Photon.MonoBehaviour {

	private Quaternion correctPlayerRot;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (!photonView.isMine)
		{
			transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			// We own this player: send the others our data
			stream.SendNext(transform.rotation);
		}
		else
		{
			// Network player, receive data
			this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
		}
	}
}
