using UnityEngine;
using System.Collections;

public class BarController : MonoBehaviour {

    public RectTransform topBar, botBar;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void setTopBar(int percent)
    {
        topBar.sizeDelta = new Vector2(2 * percent, 30);
    }

    public void setBotBar(int percent)
    {
        botBar.sizeDelta = new Vector2(2 * percent, 30);
    }
}
