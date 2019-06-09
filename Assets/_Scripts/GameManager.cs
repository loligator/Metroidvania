using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager GM;

    private Text debugText;

	// Use this for initialization
	void Start () {
        if (GM == null) {
            GM = this;
        } else {
            GameObject.Destroy(gameObject);
        }

        debugText = GameObject.FindGameObjectWithTag("Debug").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Debug(string msg) {
        debugText.text = msg;
    }

    public void Debug(float msg) {
        debugText.text = msg.ToString("0.00");
    }
}
