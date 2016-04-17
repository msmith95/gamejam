using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	PlayerHealth ph;

    public int speed;
    Rigidbody rb;

    public int squirtFill;
    public int balloonFill;
    public float fillDelay;
    float nextFill;
    public BarrelController barrel;
    
	public void activeScript(){
		PlayerPlaneAligner align = gameObject.GetComponentInChildren<PlayerPlaneAligner> ();
		align.enabled = true;
		align.activeScript ();
	}

    // Use this for initialization
    void Start () {
		ph = GameObject.FindGameObjectWithTag ("Scripts").GetComponent<PlayerHealth> () as PlayerHealth;

        rb = GetComponent<Rigidbody>();

        nextFill = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = new Quaternion();

        float hmove = Input.GetAxis("Horizontal");
        float vmove = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hmove, 0f, vmove);

        rb.velocity = movement * speed;


        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(gameObject.tag))
        {
            if(Time.time > nextFill)
            {
                barrel.refillSupplies(squirtFill, balloonFill);

                nextFill = Time.time + fillDelay;
            }
            
        }

    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("balloon"))
		{
			if (gameObject.CompareTag ("greenTeam") && other.gameObject.GetComponent<fire> ().getTeam () == 1) {
				ph.decPH1 (10);
				Destroy (other.gameObject);
			}
			if (gameObject.CompareTag ("blueTeam") && other.gameObject.GetComponent<fire> ().getTeam () == 0) {
			
				ph.decPH2 (10);
				Destroy (other.gameObject);
			}

		}
		else if (other.gameObject.CompareTag("squirt"))
		{
			if (gameObject.CompareTag ("greenTeam") && other.gameObject.GetComponent<fire> ().getTeam () == 1) {

				ph.decPH1 (1);
				Destroy (other.gameObject);
			}
			if (gameObject.CompareTag ("blueTeam") && other.gameObject.GetComponent<fire> ().getTeam () == 0) {
				ph.decPH2 (1);
				Destroy (other.gameObject);
			}
		}
	}
}
