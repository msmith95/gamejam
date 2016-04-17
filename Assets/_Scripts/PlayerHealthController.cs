using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour {

    PlayerHealth ph;

    public Text healthText1, healthText2;
    public int totalHealth;

    // Use this for initialization
    void Start()
    {
        ph = GameObject.FindGameObjectWithTag("Scripts").GetComponent<PlayerHealth>();
        print(ph.getPH1());

        healthText1 = GameObject.FindGameObjectWithTag("PH1").GetComponent<Text>() as Text;
        healthText2 = GameObject.FindGameObjectWithTag("PH2").GetComponent<Text>() as Text;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("greenTeam")) totalHealth = ph.getPH1();
        if (gameObject.CompareTag("blueTeam")) totalHealth = ph.getPH2();

        if (gameObject.CompareTag("greenTeam")) healthText1.text = ph.getPH1().ToString();
        if (gameObject.CompareTag("blueTeam")) healthText2.text = ph.getPH2().ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("balloon"))
        {
            if (gameObject.CompareTag("greenTeam") && other.GetComponent<fire>().getTeam() == 1)
            {
                ph.decPH1(10);
                Destroy(other.gameObject);

            }
            if (gameObject.CompareTag("blueTeam") && other.GetComponent<fire>().getTeam() == 0)
            {
                ph.decPH2(10);
                Destroy(other.gameObject);
            }
            
        }
        else if (other.gameObject.CompareTag("squirt"))
        {
            if (gameObject.CompareTag("greenTeam") && other.GetComponent<fire>().getTeam() == 1)
            {
                ph.decPH1(1);
                Destroy(other.gameObject);
            }
            if (gameObject.CompareTag("blueTeam") && other.GetComponent<fire>().getTeam() == 0)
            {
                ph.decPH2(1);
                Destroy(other.gameObject);
            }
        }
    }
}
