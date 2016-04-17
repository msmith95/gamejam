using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

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
}
