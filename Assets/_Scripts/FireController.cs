using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FireController : MonoBehaviour {

    public Text healthText;

    public int totalHealth;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        healthText.text = "HP - " + totalHealth.ToString();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("balloon"))
        {
            totalHealth -= 10;
            Destroy(other.gameObject);
        }
    }
}
