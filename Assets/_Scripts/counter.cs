using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class counter : MonoBehaviour {

    public BarController tl, tr, br;

    int count;
    float nextCount;
    public float delay;

	// Use this for initialization
	void Start () {
        nextCount = 0f;
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Time.time > nextCount)
        {
            count += 1;
            nextCount = Time.time + delay;

            gameObject.GetComponent<Text>().text = count.ToString();
        }

        if (count == 100) count = 0;

        tl.setTopBar(count);
        tl.setBotBar(100 -count);

        tr.setTopBar(count);
        tr.setBotBar(100 -count);

        br.setTopBar(count);
        br.setBotBar(100 -count);
    }
}
