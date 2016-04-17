using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    int playerHealth1, playerHealth2;
    public int maxHealth;

    // Use this for initialization
    void Start()
    {
        playerHealth1 = maxHealth;
        playerHealth2 = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getPH1()
    {
        return playerHealth1;
    }
    public int getPH2()
    {
        return playerHealth2;
    }

    public void decPH1(int amount)
    {
        playerHealth1 -= amount;
    }
    public void decPH2(int amount)
    {
        playerHealth2 -= amount;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(playerHealth1);
            stream.SendNext(playerHealth2);
        }
        else
        {
            // Network player, receive data
            playerHealth1 = (int)stream.ReceiveNext();
            playerHealth2 = (int)stream.ReceiveNext();
        }
    }
}
