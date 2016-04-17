using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FireController : MonoBehaviour {

    public FireHealth fh;

    public Text healthText;

    public int totalHealth;
    public BarController f1h, f2h, supplies;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        print(fh.getFH1() + " / " + totalHealth);
        f1h.setBotBar(fh.getFH1());
        f1h.setBotBar(fh.getFH1());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("balloon"))
        {
            if (gameObject.CompareTag("greenTeam")) fh.decFH1(10);
            if (gameObject.CompareTag("blueTeam")) fh.decFH2(10);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("squirt"))
        {
            if (gameObject.CompareTag("greenTeam")) fh.decFH1(1);
            if (gameObject.CompareTag("blueTeam")) fh.decFH2(1);
            Destroy(other.gameObject);
        }
    }
}
