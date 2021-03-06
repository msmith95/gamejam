﻿using UnityEngine;
using System.Collections;

public class FireHealth : MonoBehaviour {

    int fireHealth1, fireHealth2;
    public int maxHealth;

	// Use this for initialization
	void Start () {
        fireHealth1 = maxHealth;
        fireHealth2 = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getFH1()
    {
        return fireHealth1;
    }
    public int getFH2()
    {
        return fireHealth2;
    }

    public void decFH1(int amount)
    {
        fireHealth1 -= amount;
    }
    public void decFH2(int amount)
    {
        fireHealth2 -= amount;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(fireHealth1);
            stream.SendNext(fireHealth2);
        }
        else
        {
            // Network player, receive data
            fireHealth1 = (int)stream.ReceiveNext();
            fireHealth2 = (int)stream.ReceiveNext();
        }
    }
}
