using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour {

    public PlayerHealth ph;

    public Text healthText;

    public int totalHealth;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("greenTeam")) totalHealth = ph.getPH1();
        if (gameObject.CompareTag("blueTeam")) totalHealth = ph.getPH2();

        healthText.text = "HP - " + totalHealth.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("balloon"))
        {
            if (gameObject.CompareTag("greenTeam") && other.GetComponent<fire>().getTeam() == 1) ph.decPH1(10);
            if (gameObject.CompareTag("blueTeam") && other.GetComponent<fire>().getTeam() == 0) ph.decPH2(10);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("squirt"))
        {
            if (gameObject.CompareTag("greenTeam") && other.GetComponent<fire>().getTeam() == 1) ph.decPH1(1);
            if (gameObject.CompareTag("blueTeam") && other.GetComponent<fire>().getTeam() == 0) ph.decPH2(1);
            Destroy(other.gameObject);
        }
    }
}
