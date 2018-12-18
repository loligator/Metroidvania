using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager GM;

    private TextMeshProUGUI debugText;

	// Use this for initialization
	void Start () {
        debugText = GameObject.FindGameObjectWithTag("Debug");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    static void Debug(string msg) {
        debugText.text = 
    }
}
